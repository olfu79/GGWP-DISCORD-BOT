using System;
using System.IO;
using System.Net.Http;
using System.Numerics;
using System.Threading.Tasks;
using Discord;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;
using SixLabors.Shapes;


namespace ggwp.Services
{
    public static class ImageBuilders
    {
        public static async Task GetUserAvatar (IUser user, string saveas)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            HttpClientHandler handler = new HttpClientHandler();
            using (var httpClient = new HttpClient(handler, false))
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, user.GetAvatarUrl()))
                {
                    using (
                        Stream contentStream = await (await httpClient.SendAsync(request)).Content.ReadAsStreamAsync(),
                        stream = new FileStream(saveas, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
                    {
                        await contentStream.CopyToAsync(stream);
                    }
                }
            }
        }

        public static async Task MakeImageRound (string load, string saveas)
        {
            using (var img = SixLabors.ImageSharp.Image.Load(load))
            {
                using (Image<Rgba32> destRound = img.Clone(x => x.ConvertToAvatar(new Size(128, 128), 64)))
                {
                    destRound.Save(saveas);
                }
            }
        }

        public static IImageProcessingContext<Rgba32> ConvertToAvatar(this IImageProcessingContext<Rgba32> processingContext, Size size, float cornerRadius)
        {
            return processingContext.Resize(new ResizeOptions
            {
                Size = size,
                Mode = ResizeMode.Crop
            }).Apply(i => ApplyRoundedCorners(i, cornerRadius));
        }

        public static void ApplyRoundedCorners(Image<Rgba32> img, float cornerRadius)
        {
            IPathCollection corners = BuildCorners(img.Width, img.Height, cornerRadius);

            var graphicOptions = new GraphicsOptions(true)
            {
                BlenderMode = PixelBlenderMode.Src // enforces that any part of this shape that has color is punched out of the background
            };
            // mutating in here as we already have a cloned original
            img.Mutate(x => x.Fill(graphicOptions, Rgba32.Transparent, corners));
        }

        public static Image<Rgba32> CloneAndConvertToAvatarWithoutApply(this Image<Rgba32> image, Size size, float cornerRadius)
        {
            Image<Rgba32> result = image.Clone(
                ctx => ctx.Resize(
                    new ResizeOptions
                    {
                        Size = size,
                        Mode = ResizeMode.Crop
                    }));

            ApplyRoundedCorners(result, cornerRadius);
            return result;
        }

        public static IPathCollection BuildCorners(int imageWidth, int imageHeight, float cornerRadius)
        {
            // first create a square
            var rect = new RectangularPolygon(-0.5f, -0.5f, cornerRadius, cornerRadius);

            // then cut out of the square a circle so we are left with a corner
            IPath cornerToptLeft = rect.Clip(new EllipsePolygon(cornerRadius - 0.5f, cornerRadius - 0.5f, cornerRadius));

            // corner is now a corner shape positions top left
            //lets make 3 more positioned correctly, we can do that by translating the orgional artound the center of the image
            var center = new Vector2(imageWidth / 2F, imageHeight / 2F);

            float rightPos = imageWidth - cornerToptLeft.Bounds.Width + 1;
            float bottomPos = imageHeight - cornerToptLeft.Bounds.Height + 1;

            // move it across the widthof the image - the width of the shape
            IPath cornerTopRight = cornerToptLeft.RotateDegree(90).Translate(rightPos, 0);
            IPath cornerBottomLeft = cornerToptLeft.RotateDegree(-90).Translate(0, bottomPos);
            IPath cornerBottomRight = cornerToptLeft.RotateDegree(180).Translate(rightPos, bottomPos);

            return new PathCollection(cornerToptLeft, cornerBottomLeft, cornerTopRight, cornerBottomRight);
        }
    }
}

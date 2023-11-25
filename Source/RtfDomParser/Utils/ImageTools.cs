using System.Numerics;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace RtfDomParser.Utils
{
    internal static class ImageTools
    {
        public static int GetAlpha(this Color color)
        {
            return (int)((Vector4)color).W;
        }

        public static (int R, int G, int B, int A) Extract(this Color color)
        {
            var vector = (Vector4)color;
            var r = (int)vector.X;
            var g = (int)vector.Y;
            var b = (int)vector.Z;
            var a = (int)vector.W;
            return (R: r, G: g, B: b, A: a);
        }

        public static uint ToArgb(this Color color)
        {
            return color.ToPixel<Argb32>().Argb;
        }

        public static Color FromArgb(int a, int r, int g, int b)
        {
            return Color.FromRgba((byte)r, (byte)g, (byte)b, (byte)a);
        }

        public static Color ColorEmpty => default;
    }
}
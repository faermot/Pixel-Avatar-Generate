using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace PAG
{
    public class ImageRender
    {
        private AvatarData _data;
        private const int Resolution = 1080;

        public ImageRender(AvatarData data, bool scaling = true)
        {
            _data = data;
            int pixelSize = Resolution / data.Size;

            if (scaling)
            {
                using (Image<Rgba32> image = new Image<Rgba32>(Resolution, Resolution))
                {
                    for (int i = 0; i < data.Size; i++)
                    {
                        for (int j = 0; j < data.Size; j++)
                        {
                            Rgba32 color = data.Pixels[i, j] == 0
                                ? Rgba32.ParseHex("#ffffff")
                                : Rgba32.ParseHex(data.Color);

                            for (int dy = 0; dy < pixelSize; dy++)
                                for (int dx = 0; dx < pixelSize; dx++)
                                    image[j * pixelSize + dx, i * pixelSize + dy] = color;
                        }
                    }
                    image.SaveAsPng("output.png");
                }
            }
            else
            {
                using (Image<Rgba32> image = new Image<Rgba32>(data.Size, data.Size))
                {
                    for (int i = 0; i < data.Size; i++)
                    {
                        for (int j = 0; j < data.Size; j++)
                        {
                            if (data.Pixels[i, j] == 0)
                                image[j, i] = Rgba32.ParseHex("#ffffff");
                            else
                                image[j, i] = Rgba32.ParseHex(data.Color);
                        }
                    }


                    image.SaveAsPng("output.png");
                }
            } 
        }
    }
}

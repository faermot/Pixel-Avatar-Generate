using PAG;

namespace PixelAvatarGenerate
{
    class Program
    {
        static void Main(string[] args)
        {
            AvatarGenerator generator = new AvatarGenerator("dobzhik", 8);
            ImageRender render = new ImageRender(generator.Generate());

            Console.ReadKey();
        }
    }
}
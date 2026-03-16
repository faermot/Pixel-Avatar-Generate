using PAG;

namespace PixelAvatarGenerate
{
    class Program
    {
        static void Main(string[] args)
        {
            AvatarGenerator generator = new AvatarGenerator("dobzhik", 8);
            ImageRender render = new ImageRender(generator.Generate());
            Console.WriteLine("Изображение 'output.png' успешно сохранено в папке с программой!");

            Console.ReadKey();
        }
    }
}
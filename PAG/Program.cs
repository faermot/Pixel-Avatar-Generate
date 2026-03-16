using PAG;

namespace PixelAvatarGenerate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите никнейм: ");
            string nickname = Console.ReadLine();

            int size;
            Console.Write("Введите размер: ");
            while (!int.TryParse(Console.ReadLine(), out size))
            {
                Console.Write("Ошибка! Пожалуйста, введите корретное значение (например 5): ");
            }

            AvatarGenerator generator = new AvatarGenerator(nickname, size);
            ImageRender render = new ImageRender(generator.Generate());
            
            Console.WriteLine("\n\nИзображение 'output.png' успешно сохранено в папке с программой!");

            Console.ReadKey();
        }
    }
}
using System.Security.Cryptography;
using System.Text;

namespace PAG
{
    public class AvatarGenerator
    {
        private string _username;
        private int _size;

        public AvatarGenerator(string username, int size)
        {
            _username = username;
            _size = size;
        }

        public AvatarData Generate()
        {
            byte[] bytes = GetHash();
            int[,] pixels = GenerateArray(bytes);
            string color = GetColor(bytes);


            return new AvatarData(pixels, color, _size);
        }

        byte[] GetHash()
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(_username));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                Console.WriteLine("SHA256 Hash: {0}", builder.ToString());
                return bytes;
            }
        }

        string GetColor(byte[] bytes)
        {
            return $"#{bytes[bytes.Length - 3]:X2}{bytes[bytes.Length - 2]:X2}{bytes[bytes.Length - 1]:X2}";
        }

        int f()
        {
            int m = _size - 2;
            return m * ((m + 1) / 2);
        }

        int[,] ConvertToMatrix(string bits)
        {
            int m = _size - 2;
            int x = m, y = ((m + 1) / 2);


            int[,] matrix = new int[x, y];

            int index = 0;

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = bits[index] - '0';
                    index++;
                }
            }


            int[,] sym;

            bool isEven = m % 2 == 0;

            if (isEven) sym = new int[x, y * 2];
            else sym = new int[x, y * 2 - 1];

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    sym[i, j] = matrix[i, j];
                }

                if (isEven)
                {
                    for (int j = 0; j < y; j++)
                        sym[i, y * 2 - 1 - j] = matrix[i, j];
                }
                else
                {
                    for (int j = 0; j < y - 1; j++)
                        sym[i, y * 2 - 2 - j] = matrix[i, j];
                }
            }



            // Display(matrix);
            // Display(sym);

            return sym;
        }

        int[,] GenerateArray(byte[] bytes)
        {
            int inside_size = f();
            string bits = "";
            for (int i = 0; i < inside_size; i++)
            {
                int byteIndex = (i / 8) % bytes.Length;
                int bitIndex = i % 8;
                int bit = (bytes[byteIndex] >> bitIndex) & 1;
                bits += bit;
            }

            int[,] sym = ConvertToMatrix(bits);

            int[,] full = new int[_size, _size];
            for (int i = 0; i < sym.GetLength(0); i++)
                for (int j = 0; j < sym.GetLength(1); j++)
                    full[i + 1, j + 1] = sym[i, j];

            return full;
        }



        void Display(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
        }

    }

    public class AvatarData
    {
        public int[,] Pixels { get; set; }
        public string Color { get; set; }
        public int Size { get; set; }

        public AvatarData(int[,] pixels, string color, int size)
        {
            Pixels = pixels;
            Color = color;
            Size = size;
        }
    }
}

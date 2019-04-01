using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithmsOfProtectingInformation5
{
    class Gamma
    {
        // Some fields for storing input and output data.
        private static string text;
        private static string encryptedText;
        private static byte[] arrayOfASCII;
        private static int[] gammaKeys;
        private static int a = new int();
        private static int b = new int();
        private static int m = new int();
        private static int Y0 = new int();

        // General method for encryption.
        public static void Encryption()
        {
            GetValues();
            CalculateGamma();
            EncryptText();
        }

        // Method for getting values from input stream.
        private static void GetValues()
        {
            Console.Write("Enter your text: ");
            text = Console.ReadLine();
            arrayOfASCII = Encoding.ASCII.GetBytes(text);
            GetA();
            GetBAndM();
            GetY0();
            Console.WriteLine($"\n\na = {a}, b = {b}, m = {m}, Y0 = {Y0}\n");
            
        }

        // Method for encryption text from input stream.
        private static void EncryptText()
        {
            for (int i = 0; i < text.Length; i++)
            {
                encryptedText += Convert.ToChar(arrayOfASCII[i] ^ gammaKeys[i]);
            }

            Console.WriteLine($"\n\nHere is encrypted text: {encryptedText}\n");
        }

        // Method for calculating gamma.
        private static void CalculateGamma()
        {
            gammaKeys = new int[text.Length];
            gammaKeys[0] = Y0;
            for (int i = 1; i < text.Length; i++)
            {
                gammaKeys[i] = ((a * gammaKeys[i - 1]) + b) % m;
            }

            Console.WriteLine("\nHere is gamma: ");
            foreach (int key in gammaKeys)
            {
                Console.Write(key + " ");
            }
            Console.WriteLine();
        }

        // Method for checking is two integers coprime.
        private static bool IsCoprime(int a, int b)
        {
            return a == b
                   ? a == 1
                   : a > b
                        ? IsCoprime(a - b, b)
                        : IsCoprime(b - a, a);
        }

        // Method for reading and checking 'a'.
        private static void GetA()
        {
            do
            {
                Console.Write("\n\nEnter a(odd, a mod 4 = 1): ");
                if (int.TryParse(Console.ReadLine(), out a))
                {
                    if (a % 4 == 1)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("a mod 4 = 1!!!!! Try again!");
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input!");
                }


            } while (true);
        }

        // Method for reading and checking 'b' and 'm'.
        private static void GetBAndM()
        {
            do
            {
                Console.WriteLine("\n\nEnter coprime integers!!!\n");
                Console.Write("\nEnter b(It should be odd!): ");
                while (int.TryParse(Console.ReadLine(), out b) == false)
                {
                    Console.Write("Wrong 'b' input! Try again: ");
                }
                Console.Write("\n\nEnter m(It should be odd!): ");
                while (int.TryParse(Console.ReadLine(), out m) == false)
                {
                    Console.Write("Wrong 'm' input! Try again: ");
                }

                if (IsCoprime(b, m))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"\n{b} and {m} aren't coprime!!! Try again!");
                }


            } while (true);
        }
        // Method for reading and checking 'Y0'.
        private static void GetY0()
        {
            do
            {
                Console.Write("\n\nEnter Y0( > 0): ");
                if(int.TryParse(Console.ReadLine(), out Y0))
                {
                    if (Y0 > 0)
                    {
                        break;
                    }
                }
            } while (true);
        }
    }
}

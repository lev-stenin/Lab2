using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication
{
    class Program
    {
        public static int BinarySearch(int[] array, int value)
        {
            if (array == null) 
            {
                return -1;
            }
            var left = 0;
            var right = array.Length - 1;
            while (left <= right)
            {
                var middle = (right + left) / 2;
                if (value < array[middle])
                {
                    right = middle - 1;
                    continue;
                }
                if (value > array[middle])
                {
                    left = middle + 1;
                    continue;
                }
                return middle;
            }

            return -1;
        }

        static void Main(string[] args)
        {
            TestNegativeNumbers();
            TestNonExistentElement();
            TestFiveElement();
            TestElementSeveralTimes();
            TestNullMassiv();
            TestOneElementIn100001BigMassiv();

            Console.ReadKey();
        }

        private static void TestNegativeNumbers()
        {
            //Тестирование поиска в отрицательных числах
            int[] negativeNumbers = new[] { -5, -4, -3, -2 };
            if (BinarySearch(negativeNumbers, -3) != 2)
                Console.WriteLine("! Поиск не нашёл число -3 среди чисел {-5, -4, -3, -2}");
            else
                Console.WriteLine("Поиск среди отрицательных чисел работает корректно");
        }
        private static void TestNonExistentElement()
        {
            //Тестирование поиска отсутствующего элемента
            int[] negativeNumbers = new[] { -5, -4, -3, -2 };
            if (BinarySearch(negativeNumbers, -1) >= 0)
                Console.WriteLine("! Поиск нашёл число -1 среди чисел {-5, -4, -3, -2}");
            else
                Console.WriteLine("Поиск отсутствующего элемента работает корректно");
        }
        private static void TestFiveElement()       
        {
            //Тестирование поиска одного элемента в массиве из 5 элементов
            int[] numbers = new[] { 1, 4, 6, 25, 44 };
            if (BinarySearch(numbers, 25) != 3)
                Console.WriteLine("! Поиск не нашёл число 25 среди чисел { 1, 4, 6, 25, 44 }");
            else
                Console.WriteLine("Поиск одного элемента в массиве из 5 элементов работает корректно");

        }

        private static void TestElementSeveralTimes()
        {
            //Тестирование поиска элемента, повторяющегося несколько раз
            int[] number = new[] { 3, 3, 5, 6, 7 };
            if (number[BinarySearch(number, 3)] != 3)
                Console.WriteLine("Поиск не нашёл число 3 среди чисел, которые повторяются несколько раз ");
            else
                Console.WriteLine("Поиск элемента, повторяющегося несколько раз, работает корректно");

        }
        private static void TestNullMassiv()
        {
            //Тестирование поиска в пустом массиве
            int[] nullmassiv = { };
            if (BinarySearch(nullmassiv, 6) != -1)        
                Console.WriteLine("Поиск в пустом массиве работает некорректно ");
            else
                Console.WriteLine("Поиск в пустом массиве работает корректно");

        }
        private static void TestOneElementIn100001BigMassiv()
        {
            //Тестирование поиска в массиве из 100001 элементов 
            int[] bigmassiv = new int[100001];
            Random random = new Random();
            for (int i = 0; i < 100001; i++)
            {
                bigmassiv[i] = random.Next(1, 100002);
            }
            int index = random.Next(1, 100002);
            Array.Sort(bigmassiv);
            int number = bigmassiv[index];
            if (bigmassiv[BinarySearch(bigmassiv, number)] != number)
            {
                Console.WriteLine("Поиск в массиве из 100001 элементов работает некорректно");
            }
            else
            {
                Console.WriteLine("Поиск в массиве из 100001 элементов работает корректно");
            }
        }


    }
}
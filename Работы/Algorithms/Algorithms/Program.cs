using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[8];

            //RndAr(ref a, 1, 24);
            //PrAr(a);
            //Sorting.BubbleUp(ref a);
            //PrAr(a);
            //Console.Write("\n");

            //RndAr(ref a, 1, 24);
            //PrAr(a);
            //Sorting.BubbleDw(ref a);
            //PrAr(a);
            //Console.Write("\n");

            //RndAr(ref a, 1, 24);
            //PrAr(a);
            //Sorting.SlуcUp(ref a);
            //PrAr(a);
            //Console.Write("\n");

            //RndAr(ref a, 1, 24);
            //PrAr(a);
            //Sorting.SlуcDw(ref a);
            //PrAr(a);
            //Console.Write("\n");

            //int n = Convert.ToInt32(Console.ReadLine());
            //if (n > 0)
            //{
            //    for (int i = 1; i <= n; i++)
            //        Console.Write($"{Different.Fib(i)} ");
            //}  

            /*Нахождение факториала (Нерекурсивно)*/
            //int n = Convert.ToInt32(Console.ReadLine());
            //int fct = n;
            //if (n > 0)
            //{
            //    for (int i = 2; i < n; i++)
            //        fct *= i;
            //    Console.WriteLine(fct);
            //}
            //else if (n == 0)
            //    Console.WriteLine(1);
            //else
            //    Console.WriteLine("Ошибка");

            /*Нахождение факториала (Рекурсивно)*/
            //int n = Convert.ToInt32(Console.ReadLine());
            //if (n >= 0)
            //    Console.WriteLine(Different.Fct(n));
            //else
            //    Console.WriteLine("Ошибка");

            //string st = Console.ReadLine();
            //Console.WriteLine(Different.Flip(st));

            //RndAr(ref a, 1, 24);
            //PrAr(a);
            //int key = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine(Search.Line(a, key));

            Console.ReadKey();
        }

        static void RndAr(ref int[] a, int p, int q)
        {
            Random rnd = new Random();
            int n = a.Length;
            for (byte i = 0; i < n; i++)
                a[i] = rnd.Next(p, q + 1);
        }

        static void PrAr(int[] a)
        {
            int n = a.GetLength(0);
            for (byte i = 0; i < n; i++)
                Console.Write($"{a[i]} ");
            Console.Write("\n");
        }
    }

    class Sorting
    {
        //Сортировка метод пузырька
        public static void BubbleUp(ref int[] a)
        {
            int n = a.Length;
            for(int i = 0; i < n; i++)
                for (int j = 0; j < n - 1 - i; j++)
                    if (a[j] > a[j + 1])
                    {
                        a[j] = a[j] + a[j + 1];
                        a[j + 1] = a[j] - a[j + 1];
                        a[j] = a[j] - a[j + 1];
                    }
        }

        public static void BubbleDw(ref int[] a)
        {
            int n = a.Length;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n - 1 - i; j++)
                    if (a[j] < a[j + 1])
                    {
                        a[j] = a[j] + a[j + 1];
                        a[j + 1] = a[j] - a[j + 1];
                        a[j] = a[j] - a[j + 1];
                    }
        }

        //Сортировка выбором
        public static void SlуcUp(ref int[] a)
        {
            int n = a.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < n; j++)
                    if (a[j] < a[min])
                        min = j;

                int t = a[i];
                a[i] = a[min];
                a[min] = t;
            }
        }

        public static void SlуcDw(ref int[] a)
        {
            int n = a.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int max = i;
                for (int j = i + 1; j < n; j++)
                    if (a[j] > a[max])
                        max = j;

                int t = a[i];
                a[i] = a[max];
                a[max] = t;
            }
        }
    }

    class Search
    {
        //Линейный поиск
        public static int Line(int[] a, int key)
        {
            for (int i = 0; i < a.Length; i++)
                if (a[i] == key)
                    return i;

            return -1;
        }

        //Бинарный поиск (производится только в упорядоченной последовательности) //МЕТОД РАБОТАЕТ НЕПРАВИЛЬНО
        //Ошибка возникает если приходится распознать самый последний эллемент последовательности
        public static int BinUp(int[] a, int key)
        {
            int n = a.Length;

            if (n == 0) return -1;

            if (a[n / 2] == key)
            {
                return n / 2;
            }
            else if (a[n / 2] > key)
            {
                int[] b = new int[n / 2];
                Array.Copy(a, b, n / 2);
                return BinUp(b, key);
            }
            else
            {
                if (n / 2 == 0)
                {
                    int[] b = new int[n / 2];
                    Array.ConstrainedCopy(a, n / 2 + 1, b, 0, n / 2);
                    if (BinUp(b, key) == -1)
                        return -1;
                    else
                        return BinUp(b, key) + (n / 2 + 1);
                }
                else
                {
                    int[] b = new int[n / 2 - 1];
                    Array.ConstrainedCopy(a, n / 2 + 1, b, 0, n / 2 - 1);
                    if (BinUp(b, key) == -1)
                        return -1;
                    else
                        return BinUp(b, key) + (n / 2 + 1);
                }
            }
        }
    }

    class Different
    {
        //Нахождение n-го числа Фибоначчи
        public static int Fib(int n)
        {
            if (n <= 2)
                return 1;
            else
                return Fib(n - 1) + Fib(n - 2);
        }

        //Нахождение факториала (Рекурсивно)
        public static int Fct(int n)
        {
            if (n == 0 || n == 1)
                return 1;
            
            return Fct(n - 1) * n;
        }

        //Переворачивание строки
        public static string Flip(string a)
        {
            StringBuilder fl = new StringBuilder(a);
            int n = fl.Length;
            for (int i = 0; i < n / 2; i++)
            {
                char k = fl[i];
                fl[i] = fl[(n - 1) - i];
                fl[(n - 1) - i] = k;
            }
            return fl.ToString();
        }
    }
}

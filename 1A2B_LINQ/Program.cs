using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1A2B_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {


            for (int i = 1; i != 0; i++)
            {
                //亂數
                Random random = new Random();

                string[] arr = new string[4];


                for (int j = 0; j <= 3; j++)
                {
                    arr[j] = Convert.ToString(random.Next(1, 10));
                    for (int k = 0; k < j; k++)
                    {
                        if (arr[j] == arr[k])
                        {
                            j--;
                        }
                    }
                }
                Console.WriteLine("歡迎來到1A2B猜數字遊戲~");
                foreach (string str in arr)
                {
                    Console.WriteLine(str);
                }



                for (int y = 1; y != 0; y++)
                {
                    int a = 0, b = 0;
                    Console.WriteLine("請輸入4個不重複的數字");
                    string[] play = new string[4];
                    string num = Console.ReadLine();

                    for (int z = 0; z < 4; z++)
                    {
                        play[z] = Convert.ToString(num[z]);
                    }

                    var intersect = play.Intersect(arr);
                    foreach (string str in intersect)
                    {
                        Array.IndexOf(arr, str);
                        if (Array.IndexOf(play, str) == Array.IndexOf(arr, str))
                        {
                            a++;
                        }
                        else
                        {
                            b++;
                        }
                    }
                    Console.WriteLine($"判定結果是 {a}A{b}B");
                    if (a == 4)
                    {
                        Console.WriteLine("恭喜你!猜對了!!!");
                        break;
                    }
                }
                Console.WriteLine("是否繼續遊玩?(y/n):");
                string yorn = Console.ReadLine();
                if (yorn == "n")
                {
                    break;
                }
                else if (yorn == "y")
                {
                    continue;
                }
                else
                {
                    break;
                }

            }
            Console.ReadLine();
        }
    }
}

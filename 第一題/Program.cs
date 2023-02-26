using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices.ComTypes;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;

namespace 第一題
{
    internal class Program
    {

        static void Main(string[] args)
        {
            var products = ProcessCSV(@"C:\Users\user\Downloads\product.csv");
            int pageSelect = 0;
            string select = "";
            while (true)
            {
                Console.WriteLine("第一題作業");
                Console.WriteLine("總數4頁，按5離開畫面");
                select = Console.ReadLine();
                if ((select == null) || (select == ""))
                {
                    Console.Clear();
                    Console.WriteLine("輸入錯誤");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                else
                {
                    pageSelect = int.Parse(select);
                }
                Console.WriteLine(pageSelect);
                if (pageSelect <= 5)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("輸入錯誤");
                    Console.ReadKey();
                    Console.Clear();

                    continue;
                }

            }
            while (true)
            {
                switch (pageSelect)
                {
                    case 1:
                        while (true)
                        {
                            //1.計算所有商品的總價格
                            Console.WriteLine($"商品總價格:{products.Sum(x => x.price)}");
                            Console.WriteLine("--------------------------------");
                            
        
                                 

                            //2.計算所有商品的平均價格
                            Console.WriteLine($"商品平均價格:{products.Average(x => x.price)}");
                            Console.WriteLine("--------------------------------");

                            //3.計算商品的總數量
                            Console.WriteLine($"商品總數量:{products.Sum(x => x.quantity)}");
                            Console.WriteLine("--------------------------------");

                            //4.計算商品的平均數量
                            Console.WriteLine($"商品平均數量:{products.Average(x => x.quantity)}");
                            Console.WriteLine("--------------------------------");

                            Console.WriteLine("總數4頁，按5離開畫面");
                            select = Console.ReadLine();
                            if ((select == null) || (select == ""))
                            {
                                Console.Clear();
                                Console.WriteLine("輸入錯誤");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }
                            else
                            {
                                pageSelect = int.Parse(select);
                            }

                            if (pageSelect <= 5)
                            {
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("輸入錯誤");
                                Console.ReadKey();
                                Console.Clear();

                                continue;
                            }
                        }
                        break;
                    case 2:
                        while (true)
                        {
                            //5.找出哪一項商品最貴
                            var expensive = products.Where(x => x.price == products.Max(y => y.price));

                            foreach (var item in expensive)
                            {
                                Console.WriteLine($"最貴的商品:{item.name}");
                            }
                            Console.WriteLine("--------------------------------");

                            //6.找出哪一項商品最便宜
                            var cheap = products.Where(x => x.price == products.Min(y => y.price));

                            foreach (var item in cheap)
                            {
                                Console.WriteLine($"最便宜的商品:{item.name}");
                            }
                            Console.WriteLine("--------------------------------");

                            //7.計算產品類別為 3C 的商品總價
                            var electronic_product = products.Where(x => x.category == "3C").Sum(y => y.price);
                            Console.WriteLine($"3C 的商品總價:{electronic_product}");
                            Console.WriteLine("--------------------------------");

                            //8.計算產品類別為飲料及食品的商品總價
                            var food = products.Where(x => x.category == "飲料" || x.category == "食品").Sum(y => y.price);
                            Console.WriteLine($"飲料及食品的商品總價:{food}");
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("總數4頁，按5離開畫面");
                            select = Console.ReadLine();
                            if ((select == null) || (select == ""))
                            {
                                Console.Clear();
                                Console.WriteLine("輸入錯誤");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }
                            else
                            {
                                pageSelect = int.Parse(select);
                            }

                            if (pageSelect <= 5)
                            {
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("輸入錯誤");
                                Console.ReadKey();
                                Console.Clear();

                                continue;
                            }
                        }
                        break;
                    case 3:
                        while (true)
                        {
                            //9.找出所有商品類別為食品，而且商品數量大於 100 的商品
                            var food100 = products.Where(x => x.category == "食品" && x.quantity > 100);
                            foreach (var item in food100)
                            {
                                Console.WriteLine($"商品數量大於100的食品:{item.name}");
                            }
                            Console.WriteLine("--------------------------------");

                            //10.找出各個商品類別底下有哪些商品的價格是大於 1000 的商品
                            var commodity1000 = products.Where(x => x.price > 1000).GroupBy(x => x.category);
                            foreach (var item in commodity1000)
                            {
                                foreach (var item1 in item)
                                {
                                    Console.WriteLine($"價格大於1000的商品:{item1.category} 名稱:{item1.name}");
                                }
                            }
                            Console.WriteLine("--------------------------------");

                            //11. 呈上題，請計算該類別底下所有商品的平均價格
                            var commodity_avg = products.Where(x => x.price > 1000).GroupBy(x => x.category);
                            int[] avgtotal = new int[commodity_avg.Count()];
                            int i = 0, j = 0;
                            foreach (var item in commodity_avg)
                            {
                                foreach (var item1 in item)
                                {
                                    if (j == 0)
                                    {
                                        Console.Write(item1.category);
                                    }
                                    j++;
                                    int average = item1.price;
                                    avgtotal[i] = avgtotal[i] + average;
                                }
                                j = 0;
                                Console.WriteLine($"商品的平均價格:{avgtotal[i] / 3}");
                                i++;
                            }
                            Console.WriteLine("--------------------------------");

                            //12.依照商品價格由高到低排序
                            var commodity_height = products.OrderByDescending(x => x.price);
                            foreach (var item in commodity_height)
                            {
                                Console.WriteLine($"{item.name} {item.price}");
                            }
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("總數4頁，按5離開畫面");
                            select = Console.ReadLine();
                            select = Console.ReadLine();
                            if ((select == null) || (select == ""))
                            {
                                Console.Clear();
                                Console.WriteLine("輸入錯誤");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }
                            else
                            {
                                pageSelect = int.Parse(select);
                            }

                            if (pageSelect <= 5)
                            {
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("輸入錯誤");
                                Console.ReadKey();
                                Console.Clear();

                                continue;
                            }
                        }
                        break;
                    case 4:
                        while (true)
                        {
                            //13.依照商品數量由低到高排序
                            var commodity_low = products.OrderBy(x => x.price);
                            foreach (var item in commodity_low)
                            {
                                Console.WriteLine($"{item.name} {item.price}");
                            }
                            Console.WriteLine("--------------------------------");

                            //14.找出各商品類別底下，最貴的商品
                            var commodity_expensive = from item in products
                                                      group item by item.category into categorys
                                                      select new
                                                      {
                                                          categorys.Key,
                                                          mep = from item1 in categorys
                                                                where item1.price == categorys.Max((x) => x.price)
                                                                select item1
                                                      };
                                                        foreach(var item in commodity_expensive)
                                                        {
                                                            Console.WriteLine();
                                                        foreach(var item2 in item.mep)
                                                        {
                                                            Console.WriteLine(item2.name);
                                                        }
                                
                                                        }

                            Console.WriteLine("--------------------------------");
                            //15.找出各商品類別底下，最便宜的商品
                            var commodity_cheap = from item in products
                                                  group item by item.category into categorys
                                                  select new
                                                  {
                                                      categorys.Key,
                                                      mep = from item1 in categorys
                                                            where item1.price == categorys.Min((x) => x.price)
                                                            select item1
                                                  };
                                                  foreach(var item in commodity_cheap)
                                                  {
                                                        Console.WriteLine();
                                                        foreach(var item2 in item.mep)
                                                        {
                                                            Console.WriteLine(item2.name);
                                                        }
                                                  }


                            //16.找出價格小於等於 10000 的商品
                            var commodity10000 = products.Where(x => x.price <= 10000);
                            foreach (var item in commodity10000)
                            {
                                Console.WriteLine($"價格小於10000的商品:{item.name}");
                            }
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("總數4頁，按5離開畫面");
                            select = Console.ReadLine();
                            if ((select == null) || (select == ""))
                            {
                                Console.Clear();
                                Console.WriteLine("輸入錯誤");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }
                            else
                            {
                                pageSelect = int.Parse(select);
                            }
                            if (pageSelect <= 5)
                            {
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("輸入錯誤");
                                Console.ReadKey();
                                Console.Clear();

                                continue;
                            }
                        }
                        break;
                    case 5:
                        {
                            break;
                        }

                }

            }
        }

        static List<product> ProcessCSV(string path)
        {
         return File.ReadAllLines(path)
                    .Skip(1)
                    .Where(row => row.Length > 0)
                    .Select(product.ParseRow).ToList();
            }

    }
}



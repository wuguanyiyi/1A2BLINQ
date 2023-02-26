﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第一題
{

    public class product
    {
        public string id
        { get; set; }
        public string name
        { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public string category { get; set; }
       
        internal static product ParseRow(string row)
        {
            var columns = row.Split(',');
            return new product()
            {
                id = (columns[0]),
                name = columns[1],
                quantity = int.Parse (columns[2]),
                price = int.Parse( columns[3]),
                category = columns[4],
               
            };
        }
    }
}

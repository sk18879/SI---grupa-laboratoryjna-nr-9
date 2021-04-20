using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    class Item
    {
        public Item(int id, int price, int weight)
        {
            Id = id;
            Price = price;
            Weight = weight;
        }

        public int Id { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }

        public override string ToString()
        {
            return "Id: " + Id + " Price: " + Price + " Weight " + Weight;
        }


    }
}

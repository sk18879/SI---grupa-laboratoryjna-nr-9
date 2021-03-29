using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    class Item
    {
        public Item(int id, double price, double weight)
        {
            Id = id;
            Price = price;
            Weight = weight;
        }

        public int Id { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }

        public override string ToString()
        {
            return "Id: " + Id + " Price: " + Price + " Weight " + Weight;
        }


    }
}

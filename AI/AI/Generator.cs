using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    class Generator
    {

        int minPrice, maxPrice, minWeight, maxWeight;
        Random random = new Random();

        public Generator(int minPrice, int maxPrice, int minWeight, int maxWeight)
        {
            this.minPrice = minPrice;
            this.maxPrice = maxPrice;
            this.minWeight = minWeight;
            this.maxWeight = maxWeight;
        }


        public List<Item> Generatr(int number)
        {

            List<Item> items = new List<Item>();
            Random r = new Random();

            for (int i = 0; i < number; i++)
            {
                double price = r.Next(minPrice, maxPrice);
                double weight = r.Next(minWeight, maxWeight);

                Item item = new Item(i, price, weight);

                items.Add(item);

            }
            return items;

        }


       

    }
}

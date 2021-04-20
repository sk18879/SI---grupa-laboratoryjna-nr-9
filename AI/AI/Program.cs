using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyJson;

namespace AI
{


    class ItemSet
    {
        public List<Item> list = new List<Item>();
        public int weight, value;



        public override string ToString()
        {
            return "waga: "+weight+" wartość: "+value;
        }
    }


    class Program
    {


       


        static void Main(string[] args)
        {
       

            string path = Environment.CurrentDirectory + "/data.json";
            string json = File.ReadAllText(path);
           

            var items = json.FromJson<List<Item>>();

            int wagaDopuszczalna = 300;


            ItemSet[] itemSets = new ItemSet[100];
            





            var random = new Random();


            for (int i = 0; i < itemSets.Length; i++)
            {
                var itemSet = itemSets[i] = new ItemSet();
               

                while (true)
                {

                    var index = random.Next(0, 199);
                    var item = items[index];

                    if (itemSet.weight + item.Weight >= wagaDopuszczalna) break;

                    itemSet.value += item.Price;
                    itemSet.weight += item.Weight;
                    

                    itemSet.list.Add(item);
                   
                }

                
               

            }


            
            var allValues = itemSets.Select(itemSet => itemSet.value);
            var maxWartosc = allValues.Max();
            var maxIndex = allValues.ToList().IndexOf(maxWartosc);






            itemSets.ToList().ForEach(itemSet => Console.WriteLine(itemSet));
          


            Console.WriteLine("\nNajlepszy: \n" + itemSets[maxIndex]);
           


            Console.ReadLine();
           
           

        }

        private static void Generate()
        {
            var generator = new Generator(2, 300, 5, 50);

            var items = generator.Generatr(200);


            string json = items.ToJson();
            File.WriteAllText(Environment.CurrentDirectory + "\\data.json", json);



            items.ForEach(i => Console.WriteLine(i));
        }
    }
}

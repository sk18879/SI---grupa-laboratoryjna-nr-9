using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyJson;

namespace AI
{


    class Plecak
    {
        public List<Item> itemList = new List<Item>();
        public int weight, value;



        public override string ToString()
        {
            return "waga: "+weight+" wartość: "+value;
        }

        public void Add(Item item)
        {

            itemList.Add(item);
            value += item.Price;
            weight += item.Weight;

        }

    }


    class Program
    {





        static void Main(string[] args)
        {


            string path = Environment.CurrentDirectory + "/data.json";
            string json = File.ReadAllText(path);
            var items = json.FromJson<List<Item>>();
            var random = new Random();

            int wagaDopuszczalna = 300;
            int HMS = 20;
            Plecak[] HM = new Plecak[HMS];
         

           


            for (int i = 0; i < HM.Length; i++)
                HM[i] = generujPlecak();
            



            HM.ToList().ForEach(itemSet => Console.WriteLine(itemSet));
            Console.WriteLine("\n-----------------\n");

            Algorytm(1000);

            HM.ToList().ForEach(itemSet => Console.WriteLine(itemSet));
            Console.ReadLine();



            void Algorytm(int n)
            {
                int HMCR = 70;
                for (int i = 0; i < n; i++)
                {

                    int r1 = new Random().Next(100);
                    var nowyPlecak = new Plecak();

                    if (r1 < HMCR)
                    {

                        for (int j = 0; j < HMS; j++)
                        {

                            var index = random.Next(HM[j].itemList.Count);
                            var item = HM[j].itemList[index];

                            if (nowyPlecak.weight + item.Weight < wagaDopuszczalna)
                            nowyPlecak.Add(item);
                        }


                    }
                    else
                        nowyPlecak = generujPlecak();


                    

                    var FP = HM.Select(itemSet => itemSet.value);
                    var minValue = FP.Min();
                    var minIndex = FP.ToList().IndexOf(minValue);

                    if (HM[minIndex].value < nowyPlecak.value)
                        HM[minIndex] = nowyPlecak;

                }



            }
            Plecak generujPlecak()
            {
                var plecak = new Plecak();
                while (true)
                {

                    var index = random.Next(0, 199);
                    var item = items[index];

                    if (plecak.weight + item.Weight < wagaDopuszczalna)
                        plecak.Add(item);
                    else
                        break;
                }

                return plecak;
            }
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

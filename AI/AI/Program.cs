using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyJson;

namespace AI
{
    class Program
    {
        static void Main(string[] args)
        {


            var generator = new Generator(2, 300, 5, 50);

            var items = generator.Generatr(200);


            string json = items.ToJson();
            File.WriteAllText(Environment.CurrentDirectory + "\\data.json", json);



            items.ForEach(i => Console.WriteLine(i));
            

        }
    }
}

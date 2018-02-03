using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTLCache
{
    class Program
    {
        static void Main(string[] args)
        {
            TTLCache cache = new TTLCache(1);
            cache.Add("1", "hello");
            Console.WriteLine("Count: " + cache.Count());
            Console.WriteLine(cache.Get("1"));
            //Add some some delay here
            Console.WriteLine("Count: " + cache.Count());

            Console.ReadLine();
        }
    }
}

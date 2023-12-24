using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foresite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            KeyValueCollection<int, int> a = new KeyValueCollection<int, int>();
            Console.WriteLine(a);
            Console.WriteLine(a.Add(3, 5));
            Console.WriteLine(a.Add(2, 4));
            Console.WriteLine(a.Add(1, 2));
            Console.WriteLine(a.Add(1, 3));
            Console.WriteLine(a.Count());
            a.PrintAllKeyValuePairs();
            Console.WriteLine(a.Remove(1));
            Console.WriteLine(a.GetKeyByValue(4));
            Console.WriteLine(a.GetValueByKey(2));
            Console.WriteLine(a.ContainsKey(2));
            Console.WriteLine(a.ContainsValue(4));
            a.PrintAllKeyValuePairs();
            Console.WriteLine(string.Join(", ", a.GetAllKeys()));
            Console.WriteLine(string.Join(", ", a.GetAllValues()));
            Console.ReadLine();
        }
    }
}

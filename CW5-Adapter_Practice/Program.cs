// Name: Zachary Rose
// Date: 2/7/2023
// CSCI352
// A basic example of an adapter.The client requests a toybear, but by
//   implementing the bear adapter, we can disguise a grizzle bear
//   as a toybear.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW5_Adapter_Practice
{
    interface Bear
    {
        void maul();
        void hibernate();
    }
    class Grizzly : Bear
    {
        public void maul()
        {
            Console.WriteLine("Bear uses: maul!");
        }
        public void hibernate()
        {
            Console.WriteLine("Bear uses: hibernate!");
        }
    }
    interface ToyBear
    {
        void hug();
    }
    class TeddyBear : ToyBear
    {
        public void hug()
        {
            Console.WriteLine("Bear uses: hug!");
        }
    }
    class BearAdapter : ToyBear 
    {
        Bear bear;
        public BearAdapter(Bear bear)
        {
            this.bear = bear;
        }
        public void hug()
        {
            bear.maul();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Bear grizzly = new Grizzly();
            ToyBear teddybear = new TeddyBear();
            ToyBear secretGrizzly = new BearAdapter(grizzly);

            // Bear functions
            Console.WriteLine("Bear functions print test:");

            grizzly.maul();
            grizzly.hibernate();

            // Toybear functions
            Console.WriteLine("Toybear functions print test:");

            teddybear.hug();

            secretGrizzly.hug();

            Console.ReadKey();
        }
    }
}

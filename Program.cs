using System;

namespace c_sharp_odev_proje2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            Operations operations = new Operations();


            operations.InitPersonList();
            operations.InitCardList();

            operations.ReadOperation();








        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_management
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int n;
            FoodManager mnf = new();
            Food f = new();
            do
            {
                Console.WriteLine("1. Vao chuong trinh\t 2. Thoat chuong trinh");
                Console.WriteLine("\n Vui long chon chuc nang: ");
                n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        mnf.Menu();
                        break;
                    default:
                        Console.WriteLine("Thoat chuong trinh!!!");
                        Environment.Exit(0);
                        break;
                }
            } while (n != 0);
        }
        
    }
}

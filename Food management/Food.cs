using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_management
{
    internal class Food
    {
        public int ID { get; set; }
        public string? Name { get; set; } = null!;
        public int Weight { get; set; }
        public string? Type { get; set; } = null!;
        public string? Place { get; set; } = null!;
        public int Exprieddate { get; set; }
         public void PrintFood()
        {
            Console.WriteLine("Food Name: " + Name + "\tFood Id: " + ID + "\tWeight: " + Weight + "\tType : " + Type + "\tPlace : " + Place + "\tExprieddate : " + Exprieddate);
        }
    }
}

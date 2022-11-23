using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_management
{
    internal class FoodManager:Food
    {
        public List<Food> Listfoods = new List<Food>();
        public int AmountFoods()
        {
            int Count = 0;
            if (Listfoods != null)
            {
                Count = Listfoods.Count;
            }
            return Count;
        }
        private int GenerateID()
        {
            int max = 1;
            if (Listfoods != null && Listfoods.Count > 0)
            {
                max = Listfoods[0].ID;
                foreach (Food f in Listfoods)
                {
                    if (max < f.ID)
                    {
                        max = f.ID;
                    }
                }
                max++;
            }
            return max;
        }
        public void FoodInput()
        {
                Food f = new Food();
                f.ID = GenerateID();
                Console.Write("Enter the name of food: ");
                f.Name = Convert.ToString(Console.ReadLine());

                Console.Write("Enter the Weight of food: ");
                f.Weight = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter the type of food: ");
                f.Type = Convert.ToString(Console.ReadLine());

                Console.Write("Enter the place where your put this food in refrigerator: ");
                f.Place = Convert.ToString(Console.ReadLine());

                Console.Write("Enter the Expried Date: ");
                f.Exprieddate = Convert.ToInt32(Console.ReadLine());
                Listfoods.Add(f);
        }
        public Food SearchbyID(int ID)
        {
            Food searchResult = null!;
            if (Listfoods != null && Listfoods.Count > 0)
            {
                foreach (Food f in Listfoods)
                {
                    if (f.ID == ID)
                    {
                        searchResult = f;
                    }
                }
            }
            return searchResult;
        }
        public void SearchbyName()
        {
            string? SBN;
            Console.WriteLine("Enter name food you want to search: ");
            SBN = Console.ReadLine();
            List<Food> FindF = new();
            foreach (Food f in Listfoods)
            {
                if (f.Name.Contains(SBN))
                {
                    FindF.Add(f);
                }
            }
            foreach (Food f in FindF)
            {
                Console.WriteLine("Food Name: " + f.Name + "\tFood Id: " + f.ID + "\tWeight: " + f.Weight + "\tType : " + f.Type+ "\tPlace : " + f.Place + "\tExprieddate : " + f.Exprieddate);
            }
            if (FindF == null)
            {
                Console.WriteLine("Sreach fail");
                Menu();
            }
        }
        public bool RemoveFood(int ID)
        {
            bool IsDeleted = false;
            Food f = SearchbyID(ID);
            if (f != null)
            {
                IsDeleted = Listfoods.Remove(f);
            }
            return IsDeleted;
        }
        public void SortByExpriedDate()
        {
            Listfoods.Sort(delegate (Food f1, Food f2) {
                return f1.Exprieddate.CompareTo(f2.Exprieddate);
            });
        }
        public void SaveFile()
        {
            String filePath = "C:/Users/letha/source/repos/Food management/Food management/DB/ListFood.dat";
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.Create);
                StreamWriter fw = new StreamWriter(fs, Encoding.UTF8);
                foreach (Food f in Listfoods)
                {
                    fw.WriteLine("Food Name: " + f.Name + "\tFood Id: " + f.ID + "\tWeight: " + f.Weight + "\tType : " + f.Type + "\tPlace : " + f.Place + "\tExprieddate : " + f.Exprieddate);
                }
                fw.Flush();
                fs.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Can't save file!!!");
                Console.WriteLine(ex.Message);      
            }
        }
        public void Menu()
        {
            Console.WriteLine("\nFOOD MANAGEMENT");
            Console.WriteLine("*************************MENU**************************");
            Console.WriteLine("**  1. Add new food.                                 **");
            Console.WriteLine("**  2. Search food by name.                          **");
            Console.WriteLine("**  3. Remove Food By ID.                            **");
            Console.WriteLine("**  4. Print Food                                    **");
            Console.WriteLine("**  0. Thoat                                         **");
            Console.WriteLine("*******************************************************");
            Console.Write("Enter your choice (0-4): ");
            int key = Convert.ToInt32(Console.ReadLine());
            switch (key)
            {
                case 1:
                    string? choice = "Y";
                    while (choice != "N")
                    {
                        Console.WriteLine("Add new food: ");
                        FoodInput();
                        SaveFile();
                        Console.WriteLine("Add success do you want to add another food Y/N: ");
                        choice = Console.ReadLine();
                        choice.ToUpper();
                    }    
                    break;
                case 2:
                    string? S = "Y";
                    while (S != "N")
                    {
                        SearchbyName();
                        Console.WriteLine("Search success do you want to search another food Y/N: ");
                        S = Console.ReadLine();
                        S.ToUpper();
                    }
                    Menu();
                        break;
                case 3:
                    string? R = "Y";
                    int id;
                    while (R != "N")
                    {
                        Console.WriteLine("\n3. Remove Food.");
                        Console.Write("\nEnter the ID of Food: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        if (RemoveFood(id))
                        {
                            Console.WriteLine("\nFood id = {0} remove success.", id);
                            SaveFile();
                            Console.WriteLine("Add success do you want to search another food Y/N: ");
                            R = Console.ReadLine();
                            R.ToUpper();
                        }
                        else
                        {
                            Console.WriteLine("\nRemove fail!");
                            Menu();
                        }
                    }
                    Menu();
                    break;
                case 4:
                    SortByExpriedDate();
                    PrintFood();
                    break;
                default: break;
            }
        }
    }
}

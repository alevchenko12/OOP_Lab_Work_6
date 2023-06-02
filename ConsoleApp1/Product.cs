using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Work_6
{
    public class Product
    {
        public Product(double a, int e, int f, int p, int c, int d, int categ)
        {
            amount= a;
            dateExpire = d;
            energy = e;
            fat = f;
            protein = p;
            carbohydrates= c;
            productCategory = (category)categ;
        }
        //кількість в кг
        public double amount;

        //калорійність в ккал
        public int energy;

        //жири в г
        public int fat;

        //білки в г
        public int protein;

        //вугдеводи в г
        public int carbohydrates;

        //кількість днів строку придатності
        public int dateExpire;

        public category productCategory;

        //категорія 
        public enum category
        {
            Fruit = 0,
            Vegetable = 1,
            Meat = 2,
            Dairy = 3,
            Fish = 4,
            Eggs = 5,
            Sweets = 6        
        }
    }
}

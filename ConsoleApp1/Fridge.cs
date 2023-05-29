using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace Lab_Work_6
{
    public class Fridge
    {
        public Compressor comp;
        public Condenser condes;
        public Evaporator evap;
        public ExpansionValve expanvalue;
        public ShelvesStorageCompartments storage;
        public Thermostat thermo;

        //масив з продуктів 
        public Dictionary<string, Product> products;

        //об'єм холодильника
        private int volume;

        //поточна заповненість холодильника
        private int capacity;

        //кількість полиць для фруктів
        public int amountDrawersFruit = 2;

        //кількість полиць для овочів
        public int amountDrawersVeget = 3;

        //кількість лотків для яєць
        public int amountTray = 2;

        public Fridge(int v, int c)
        {
            volume = v;
            capacity= c;
            products = new Dictionary<string, Product>();
        }

        public Fridge()
        {
            volume = 20000;
            capacity = 50;
            products = new Dictionary<string, Product>();
        }

        /// <summary>
        /// зчитує файл зі списком продуктів
        /// </summary>
        public void ReadFileListProduct()
        {
            StreamReader reader = new StreamReader("ListProducts.txt");
            string line;
            reader.ReadLine();
            reader.ReadLine();
            while ((line = reader.ReadLine()) != null)
            {
                string[] words = line.Split("\t");
                string Name = words[0];
                //Product prod = new Product(double.Parse(words[1]), int.Parse(words[2]), int.Parse(words[3]), int.Parse(words[4]), int.Parse(words[5]), int.Parse(words[6]), int.Parse(words[7]));
                Product prod = new Product(Convert.ToDouble(words[1]), Convert.ToInt32(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[4]), Convert.ToInt32(words[5]), Convert.ToInt32(words[6]), Convert.ToInt32(words[7]));
                products.Add(Name, prod);
            }
            reader.Close();
        }

        /// <summary>
        /// записує в файл список прродуктів
        /// </summary>
        public void WriteFileProduct()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("The dictionary does not conain words. \n Add words before");
                return;
            }
            else
            {
                StreamWriter writer = new StreamWriter("ListProducts.txt");
                writer.WriteLine("List of Products:");
                writer.WriteLine("Name\tAmount\tDateExpire\tEnergy\tFat\tProtein\tCarbohydrates\tCategories");
                foreach (KeyValuePair<string, Product> prd in products)
                {
                    writer.WriteLine((prd.Key + "\t" + prd.Value.amount + "\t" + prd.Value.dateExpire + "\t" + prd.Value.energy + "\t" + prd.Value.fat + "\t" + prd.Value.protein + "\t" + prd.Value.carbohydrates + "\t" + (int)prd.Value.productCategory));
                }
                writer.Close();
            }
        }

        /// <summary>
        /// додавання нового прродукту
        /// </summary>
        public void AddNewProduct()
        {
            Console.WriteLine("Adding product to fridge: ");
            Console.WriteLine("Enter some info about product: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("\nAmount: ");
            int amount = Convert.ToInt32(Console.ReadLine());

            if (this.capacity + amount > volume)
            {
                Console.WriteLine("There is no free space in fridge!");
                return;
            }
            else if (products.ContainsKey(name))
            {
                products[name].amount += amount;
                Console.WriteLine(name + "is already in fridge");
                Console.WriteLine( name + " was succesfully added");
                capacity += amount;
                WriteFileProduct();
                return;
            }
            else
            {
                Console.WriteLine("This product is not yet in fridge. Eneter please more info about it:");
                Console.Write("Date expire: ");
                int dateExpire = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nEnergy: ");
                int energy = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nFat: ");
                int fat = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nProtein: ");
                int protein = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nCarbohydrates: ");
                int carbohyd = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Fruit = 0, Vegetable = 1, Meat = 2, Dairy = 3, Fish = 4, Eggs = 5, Sweets = 6");
                Console.Write("\nCategory: ");
                int category = Convert.ToInt32(Console.ReadLine());
                Product prod = new Product(amount, dateExpire, energy, fat, protein, carbohyd, category);
                products.Add(name, prod);
                Console.WriteLine(name + " was succesfully added");
                capacity += amount;
                WriteFileProduct();
                return;
            }
        }

        /// <summary>
        /// витагання продукту 
        /// </summary>
        public void RemoveProduct()
        {
            Console.WriteLine("Removing product from fridge");
            Console.WriteLine("Enter some info about product: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("\nAmount: ");
            int amount = Convert.ToInt32(Console.ReadLine());

            if (products.ContainsKey(name))
            {
                if (products[name].amount == amount)
                {
                    products.Remove(name);
                    Console.WriteLine(name + "was completely removed");
                    capacity -= amount;
                }
                else if (products[name].amount > amount)
                {
                    products[name].amount -= amount;
                    Console.WriteLine("Was removed " + amount + " of" + name);
                    capacity -= amount;
                }
                else if (products[name].amount < amount) 
                {
                    Console.WriteLine("There is only " + products[name].amount + " of " + name);
                    Console.WriteLine(name + "was completely removed, if you need more than was removed you have to buy it");
                    products.Remove(name);
                }
            }
            else
            {
                Console.WriteLine("There is no products with this name");
                Console.WriteLine("Buy it before removing it");
            }
            WriteFileProduct();
        }

        /// <summary>
        /// складання списку продуктів які потрібні для рецепту
        /// </summary>
        public void ListReceipt()
        {
            Console.WriteLine("Creating list of products to buy according to receipt of meal:");
            StreamReader reader = new StreamReader("Receipt.txt");
            string line;
            string NameReceipt = reader.ReadLine();
            reader.ReadLine();
            Dictionary<string, int> receipt = new Dictionary<string, int>();
            while ((line = reader.ReadLine()) != null)
            {
                string[] words = line.Split("\t");
                string Name = words[0];
                int amount = Convert.ToInt32(words[1]);
                receipt[Name] = amount;
            }
            reader.Close();

            StreamWriter writer = new StreamWriter("ListProductReceipt.txt");
            writer.WriteLine("List if products to buy for " + NameReceipt);
            foreach(KeyValuePair<string, int> prd in receipt)
            {
                if(products.ContainsKey(prd.Key))
                {
                    if (products[prd.Key].amount >= prd.Value)
                    {
                        //do nothing because this means you already have this product in right amount
                    }
                    if (products[prd.Key].amount < prd.Value)
                    {
                        writer.WriteLine(prd.Key + "\t" + (prd.Value - products[prd.Key].amount));
                    }
                }
                else
                {
                    writer.WriteLine(prd.Key + "\t" + prd.Value);
                }
            }
            writer.Close();
            Console.WriteLine("The list of products is created");
        }

        /// <summary>
        /// перевірка продуктів на їх строк придатності
        /// </summary>
        public void SpiledProducts()
        {
            foreach (KeyValuePair<string, Product> prd in products)
            {
                if(prd.Value.dateExpire < 0)
                {
                    Console.WriteLine(prd.Key + " has been spoiled");
                    Console.WriteLine("It is recommended to ulize it");
                }
                else if (prd.Value.dateExpire == 0)
                {
                    Console.WriteLine(prd.Key + " will spoil tomorrow");
                    Console.WriteLine("It is recomended to eat it today");
                }
                else if (prd.Value.dateExpire < 3)
                {
                    Console.WriteLine(prd.Key + " will spoil soon");
                    Console.WriteLine("It is recommended to eat it in a few days");
                } 
                else
                {
                    //do nothing because product is ok
                }
            }
        }

        public void DietRecomendation()
        {
            Console.WriteLine("Recommendation about what products to buy and eat according to diet");
            StreamReader reader = new StreamReader("Diet.txt");
            string NameDiet = reader.ReadLine();
            reader.ReadLine();
            string line;
            Dictionary<string, int> diet = new Dictionary<string, int>();
            while ((line = reader.ReadLine()) != null)
            {
                string[] words = line.Split("\t");
                string category = words[0];
                int amount = Convert.ToInt32(words[1]);
                diet.Add(category, amount);
            }
            reader.Close();

            int[] amountCategory = new int[7];
            foreach (KeyValuePair<string, Product> prd in products)
            {
                amountCategory[(int)prd.Value.productCategory] += (int)prd.Value.amount;
            }

            foreach (KeyValuePair<string, int> prd in diet)
            {
                
            }

        }

        /// <summary>
        /// віртуальний метод для написання звіту про роботу
        /// </summary>
        /// <returns></returns>
        public virtual string ReportComponent()
        {
            string info = "No info";
            return info;
        }
        
        /// <summary>
        /// віртуальний метод для написання звіту про поломку
        /// </summary>
        /// <returns></returns>
        public virtual string ReportBreackdown()
        {
            string info = "No info about breackdown. Call service center for additional info.";
            return info;
        }

        /// <summary>
        /// звістність по усім компонентам
        /// </summary>
        public void ReportAll()
        {
            comp = new Compressor();
            Console.WriteLine(comp.ReportComponent());
            condes = new Condenser();
            Console.WriteLine(condes.ReportComponent());
            evap = new Evaporator();
            Console.WriteLine(evap.ReportComponent());
            expanvalue = new ExpansionValve();
            Console.WriteLine(expanvalue.ReportComponent());
            storage = new ShelvesStorageCompartments();
            Console.WriteLine(storage.ReportComponent());
            thermo = new Thermostat();
            Console.WriteLine(thermo.ReportComponent());
        }

        public void ReportBreackAll()
        {
            comp = new Compressor();
            Console.WriteLine(comp.ReportBreackdown());
            condes = new Condenser();
            Console.WriteLine(condes.ReportBreackdown());
            evap = new Evaporator();
            Console.WriteLine(evap.ReportBreackdown());
            expanvalue = new ExpansionValve();
            Console.WriteLine(expanvalue.ReportBreackdown());
            storage = new ShelvesStorageCompartments();
            Console.WriteLine(storage.ReportBreackdown());
            thermo = new Thermostat();
            Console.WriteLine(thermo.ReportBreackdown());
        }
    }
}
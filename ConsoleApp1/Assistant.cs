using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_Work_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.Run(new Assistant());
        }
    }


    public class Assistant : System.Windows.Forms.Form
    {
        Fridge fr = new Fridge();
        ListView list = new ListView();

        public Assistant() {
            InitListHeader();
            AddFakeItems();
            list.Bounds = new Rectangle(new Point(10,10), new Size(300,200));
            list.View = View.Details;
            list.LabelEdit = true;
            this.Controls.Add(list);
        }

        private void InitListHeader() {
            ColumnHeader header = null;
            header = new ColumnHeader();
			header.Text = "Name";
			list.Columns.Add(header);
            header = new ColumnHeader();
			header.Text = "Expire";
			list.Columns.Add(header);
        }

        private void AddFakeItems() {
			ListViewItem item = null;
            item = new ListViewItem("Beer");
			item.SubItems.Add("13 days");
			list.Items.Add(item);
            item = new ListViewItem("Wine");
			item.SubItems.Add("3 days");
			list.Items.Add(item);
            item = new ListViewItem("Cream");
			item.SubItems.Add("33 days");
			list.Items.Add(item);
        }

        public void Work()
        {
            Console.WriteLine("Smart Fridge");
            Console.WriteLine("Created by Levhcenko Anastasiia IPZ 12");
            fr.ReadFileListProduct();
            char answer;
            int command;
            do
            {
                Console.WriteLine("Menu of commands:");
                Console.WriteLine("1 Add new products to fridge");
                Console.WriteLine("2 Remove products from fridge");
                Console.WriteLine("3 Check expire date of products");
                Console.WriteLine("4 Create list of products to buy according to receipt");
                Console.WriteLine("5 Write report about work of all components");
                Console.WriteLine("6 Write report about breackdown");
                Console.WriteLine("7 Change temperature");
                Console.WriteLine("8 Change preassure");
                Console.WriteLine("Select a command, press number of key:");
                command = (char)Console.Read();
                Console.ReadLine();
                switch (command)
                {
                    case '1': fr.AddNewProduct(); break;
                    case '2': fr.RemoveProduct(); break;
                    case '3': fr.SpiledProducts(); break;
                    case '4': fr.ListReceipt(); break;
                    case '5': fr.ReportAll(); break;
                    case '6': fr.ReportBreackAll(); break;
                    case '7': Compressor comp = new Compressor();  comp.ChangeTemperature(); comp.ReportComponent(); break;
                    case '8': Condenser condes = new Condenser(); condes.ChangePreassure(); condes.ReportComponent(); break;  
                    default: Console.WriteLine("The wrong command"); break;
                }
                Console.WriteLine("\n Continue y/n");
                answer = (char)Console.Read();
                Console.ReadLine();
            } while (answer != 'n');
        }
    }
}

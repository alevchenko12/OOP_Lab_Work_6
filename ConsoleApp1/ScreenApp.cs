using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Lab_Work_6
{
    class ScreenApp : System.Windows.Forms.Form {
        Fridge fr = new Fridge();
        ListView list = new ListView();
        ToolStrip toolstrip = new ToolStrip();

        public ScreenApp() {
            Size = new Size(800, 600);
            IsMdiContainer = true;
            InitListHeader();
            list.Dock = DockStyle.Fill;
            list.View = View.Details;
            list.LabelEdit = true;
            this.Controls.Add(list);
            toolstrip.Dock = DockStyle.Top;
            toolstrip.AutoSize = false;
            toolstrip.Size = new System.Drawing.Size(200, 72);
            toolstrip.Stretch = true;
            toolstrip.ImageScalingSize = new Size(72, 72);
            String image_path = "images";//Path.Combine (Path.GetDirectoryName (Application.ExecutablePath), "images");
            Image image1 = Image.FromFile (Path.Combine (image_path, "add_product.png"));
			ToolStripButton tb1 = new ToolStripButton ("&Додати продукт", image1, new EventHandler (NewProduct_Clicked));
            tb1.AutoSize = false;
            tb1.Size = new Size(72, 72);
			tb1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			toolstrip.Items.Add (tb1);
            this.Controls.Add(toolstrip);
        }

        public void NewProduct_Clicked (object sender, EventArgs e) {
            AddNewProduct addNewProduct = new AddNewProduct();
            addNewProduct.Visible = true;
        }

        public static void CreateListViewItem(String name, Product product) {
            ListViewItem item = new ListViewItem(name);
            item.SubItems.Add(product.energy.ToString());
            item.SubItems.Add(product.fat.ToString());
            item.SubItems.Add(product.protein.ToString());
            item.SubItems.Add(product.carbohydrates.ToString());
            item.SubItems.Add(Product.StringFromCategory(product.productCategory));
            item.SubItems.Add(product.dateExpire.ToString());
            item.SubItems.Add(product.amount.ToString());
        }

        private void InitListHeader() {
            ColumnHeader header = null;
            header = new ColumnHeader();
            header.Text = "Назва";
            list.Columns.Add(header);
            header = new ColumnHeader();
            header.Text = "Калорійність";
            list.Columns.Add(header);
            header = new ColumnHeader();
            header.Text = "Жири";
            list.Columns.Add(header);
            header = new ColumnHeader();
            header.Text = "Білки";
            list.Columns.Add(header);
            header = new ColumnHeader();
            header.Text = "Вуглеводи";
            list.Columns.Add(header);
            header = new ColumnHeader();
            header.Text = "Категорія";
            list.Columns.Add(header);
            header = new ColumnHeader();
            header.Text = "Строк придатності";
            list.Columns.Add(header);
            header = new ColumnHeader();
            header.Text = "Кількість";
            list.Columns.Add(header);
        }
    }
}
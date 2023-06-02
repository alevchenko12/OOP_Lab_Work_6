using System.Windows.Forms;

namespace Lab_Work_6 {
    class AddNewProduct : Form {
        Label nameLbl = new Label();
        TextBox nameTb = new TextBox();

        public AddNewProduct() {
            Size = new Size(310, 200);
            Font = new Font(Font.Name, 24, Font.Style, Font.Unit);

            nameLbl.Location = new Point(10, 10);
            nameLbl.Name = "NameLbl";
            nameLbl.Width = 100;
            nameLbl.AutoSize = true;
            nameLbl.Text = "Назва:";
            nameLbl.Font = Font;

            nameTb.Location = new Point(120, 10);
            nameTb.Width = 150;
            nameTb.Font = Font;

            Controls.AddRange(new Control[] {nameLbl, nameTb});
        }
    }
}

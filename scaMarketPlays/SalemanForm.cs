using System;
using System.Drawing;
using System.Windows.Forms;

namespace scaMarketPlays
{
    public partial class SalemanForm : Form
    {
        public SalemanForm()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void addproduct_Click(object sender, EventArgs e)
        {
            addProduct addProductForm = new addProduct();
            addProductForm.ShowDialog();

            LoadProducts();
        }

        private void LoadProducts()
        {
            string filePath = "products.txt";
            if (System.IO.File.Exists(filePath))
            {
                string[] products = System.IO.File.ReadAllLines(filePath);
                flowLayoutPanel1.Controls.Clear();

                foreach (var product in products)
                {
                    string[] details = product.Split(',');
                    if (details.Length < 5) continue;

                    string imagePath = details[0];
                    string name = details[1];
                    string price = details[2];
                    string quantity = details[3];
                    string manufacturer = details[4];

                    Panel productPanel = new Panel
                    {
                        BackColor = Color.LightGray,
                        Size = new Size(250, 300), 
                        Margin = new Padding(5),
                        BorderStyle = BorderStyle.FixedSingle
                    };

                   
                    PictureBox productImage = new PictureBox
                    {
                        Size = new Size(200, 150),
                        Location = new Point(25, 10),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    if (System.IO.File.Exists(imagePath))
                    {
                        productImage.Image = Image.FromFile(imagePath);
                    }
                    else
                    {
                        productImage.Image = SystemIcons.Error.ToBitmap();
                    }

                    Label nameLabel = new Label
                    {
                        Text = $"Название: {name}",
                        AutoSize = true,
                        Location = new Point(10, 170)
                    };

                    Label priceLabel = new Label
                    {
                        Text = $"Цена: {price}",
                        AutoSize = true,
                        Location = new Point(10, 200)
                    };
                    
                    Label quantityLabel = new Label
                    {
                        Text = $"Кол-во: {quantity}",
                        AutoSize = true,
                        Location = new Point(10, 230)
                    };

                    Label manufacturerLabel = new Label
                    {
                        Text = $"Изготовитель: {manufacturer}",
                        AutoSize = true,
                        Location = new Point(10, 260)
                    };

                    productPanel.Controls.Add(productImage);
                    productPanel.Controls.Add(nameLabel);
                    productPanel.Controls.Add(priceLabel);
                    productPanel.Controls.Add(quantityLabel);
                    productPanel.Controls.Add(manufacturerLabel);

                    flowLayoutPanel1.Controls.Add(productPanel);
                }
            }
            else
            {
                MessageBox.Show("Файл с продуктами не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scaMarketPlays
{
    public partial class buyer : Form
    {
        private Dictionary<string, int> productStock = new Dictionary<string, int>();

        public buyer()
        {
            InitializeComponent();
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
                        Size = new Size(250, 330),
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

                    Button button = new Button
                    {
                        Text = "Добавить",
                        AutoSize = true,
                        Location = new Point(10, 290)
                    };

                    button.Click += AddToBasket;

                    productPanel.Controls.Add(productImage);
                    productPanel.Controls.Add(nameLabel);
                    productPanel.Controls.Add(priceLabel);
                    productPanel.Controls.Add(quantityLabel);
                    productPanel.Controls.Add(manufacturerLabel);
                    productPanel.Controls.Add(button);

                    flowLayoutPanel1.Controls.Add(productPanel);
                }
            }
            else
            {
                MessageBox.Show("Файл с продуктами не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToBasket(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                Panel productPanel = button.Parent as Panel;
                if (productPanel != null)
                {
                    string productName = productPanel.Tag.ToString();

                    if (productStock.ContainsKey(productName) && productStock[productName] > 0)
                    {
                        productStock[productName]--;

                        foreach (Control control in productPanel.Controls)
                        {
                            if (control is Label label && label.Text.StartsWith("Кол-во"))
                            {
                                label.Text = $"Кол-во {productStock[productName]}";
                                break;
                            }
                        }

                        using (StreamWriter writer = new StreamWriter("basket.txt"))
                        {
                            writer.WriteLine(productName);
                        }
                        MessageBox.Show($"Товар добавлен в корзину");
                    }
                }
                else
                {
                    MessageBox.Show($"Товара больше нет в наличии");
                }
            }
        }
    }
}

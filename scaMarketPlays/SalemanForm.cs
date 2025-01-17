using System;
using System.Drawing;
using System.Windows.Forms;

namespace scaMarketPlays
{
    public partial class SalemanForm :Form
    {
        public SalemanForm ()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void addproduct_Click (object sender, EventArgs e)
        {
            addProduct addProductForm = new addProduct();
            addProductForm.ShowDialog();

            LoadProducts();
        }

        private void TabControl1_DrawItem (object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            if (tabControl == null)
                return;

            TabPage tabPage = tabControl.TabPages[e.Index];
            Rectangle tabRect = tabControl.GetTabRect(e.Index);
            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            Color backColor = isSelected ? Color.White : Color.RoyalBlue;
            Color foreColor = isSelected ? Color.RoyalBlue : Color.White;

            using (SolidBrush backBrush = new SolidBrush(backColor))
            using (SolidBrush textBrush = new SolidBrush(foreColor))
            {
                e.Graphics.FillRectangle(backBrush, tabRect);
                StringFormat stringFormat = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                e.Graphics.DrawString(tabPage.Text, tabControl.Font, textBrush, tabRect, stringFormat);
            }

            if (isSelected)
            {
                using (Pen borderPen = new Pen(Color.RoyalBlue, 2))
                {
                    e.Graphics.DrawRectangle(borderPen, tabRect.X, tabRect.Y, tabRect.Width - 1, tabRect.Height - 1);
                }
            }
        }

        private void LoadProducts ()
        {
            string filePath = "products.txt";
            if (System.IO.File.Exists(filePath))
            {
                string[] products = System.IO.File.ReadAllLines(filePath);
                flowLayoutPanel1.Controls.Clear();

                foreach (var product in products)
                {
                    string[] details = product.Split(',');
                    if (details.Length < 5)
                        continue;

                    string imagePath = details[0];
                    string name = details[1];
                    string price = details[2];
                    string quantity = details[3];
                    string manufacturer = details[4];

                    // Панель товара
                    Panel productPanel = new Panel
                    {
                        BackColor = Color.RoyalBlue, // Задний фон панели товара
                        Size = new Size(250, 300),
                        Margin = new Padding(5),
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    // Изображение товара
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
                    } else
                    {
                        productImage.Image = SystemIcons.Error.ToBitmap();
                    }

                    // Название товара
                    Label nameLabel = new Label
                    {
                        Text = $"Название: {name}",
                        AutoSize = true,
                        Location = new Point(10, 170),
                        ForeColor = Color.White, // Белый цвет текста
                        Font = new Font("Arial", 10, FontStyle.Bold)
                    };

                    // Цена товара
                    Label priceLabel = new Label
                    {
                        Text = $"Цена: {price}",
                        AutoSize = true,
                        Location = new Point(10, 200),
                        ForeColor = Color.White,
                        Font = new Font("Arial", 10, FontStyle.Bold)
                    };

                    // Количество товара
                    Label quantityLabel = new Label
                    {
                        Text = $"Кол-во: {quantity}",
                        AutoSize = true,
                        Location = new Point(10, 230),
                        ForeColor = Color.White,
                        Font = new Font("Arial", 10, FontStyle.Bold)
                    };

                    // Изготовитель товара
                    Label manufacturerLabel = new Label
                    {
                        Text = $"Изготовитель: {manufacturer}",
                        AutoSize = true,
                        Location = new Point(10, 260),
                        ForeColor = Color.White,
                        Font = new Font("Arial", 10, FontStyle.Bold)
                    };

                    productPanel.Controls.Add(productImage);
                    productPanel.Controls.Add(nameLabel);
                    productPanel.Controls.Add(priceLabel);
                    productPanel.Controls.Add(quantityLabel);
                    productPanel.Controls.Add(manufacturerLabel);

                    flowLayoutPanel1.Controls.Add(productPanel);
                }
            } else
            {
                MessageBox.Show("Файл с продуктами не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

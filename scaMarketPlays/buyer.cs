using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace scaMarketPlays
{
    public partial class buyer :Form
    {
        private Dictionary<string, int> productStock = new Dictionary<string, int>();

        public buyer ()
        {
            InitializeComponent();
            CustomizeDesign();
            LoadProducts();
            LoadBasket();
            DisplayUserProfile();
        }

        private void CustomizeDesign ()
        {
            // Настройка стиля NumericUpDown
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is Panel productPanel)
                {
                    foreach (Control productControl in productPanel.Controls)
                    {
                        if (productControl is NumericUpDown quantitySelector)
                        {
                            // Установка фона NumericUpDown
                            quantitySelector.BackColor = Color.White;
                            quantitySelector.ForeColor = Color.RoyalBlue;

                            // Настройка стрелок через рендеринг
                            quantitySelector.Controls[1].Paint += (sender, e) =>
                            {
                                // Рисуем стрелки в нужном цвете
                                var button = sender as Control;
                                if (button != null)
                                {
                                    // Используем цвет RoyalBlue для стрелок
                                    e.Graphics.FillRectangle(new SolidBrush(Color.RoyalBlue), button.ClientRectangle);
                                    e.Graphics.DrawString("▲", new Font("Arial", 8), Brushes.White, new PointF(10, 4)); // Стрелка вверх
                                    e.Graphics.DrawString("▼", new Font("Arial", 8), Brushes.White, new PointF(10, 20)); // Стрелка вниз
                                }
                            };

                            // Установка скроллбара в RoyalBlue
                            quantitySelector.Controls[1].BackColor = Color.RoyalBlue; // Внутренний скроллбар
                            quantitySelector.Controls[1].ForeColor = Color.White;  // Цвет текста скроллбара
                        }
                    }
                }
            }

            // Настройка внешнего вида TabControl
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.DrawItem += TabControl1_DrawItem;
            tabControl1.Font = new Font("Arial", 10, FontStyle.Bold);
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
            if (File.Exists(filePath))
            {
                string[] products = File.ReadAllLines(filePath);
                flowLayoutPanel1.Controls.Clear();

                foreach (var product in products)
                {
                    string[] details = product.Split(',');
                    if (details.Length < 5)
                        continue;

                    string imagePath = details[0];
                    string name = details[1];
                    string price = details[2];
                    int quantity = int.Parse(details[3]);
                    string manufacturer = details[4];

                    productStock[name] = quantity;

                    Panel productPanel = CreateProductPanel(imagePath, name, price, quantity, manufacturer);
                    flowLayoutPanel1.Controls.Add(productPanel);
                }
            } else
            {
                MessageBox.Show("Файл с продуктами не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CreateProductPanel (string imagePath, string name, string price, int quantity, string manufacturer)
        {
            Panel productPanel = new Panel
            {
                BackColor = Color.RoyalBlue,
                Size = new Size(250, 400),
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

            if (File.Exists(imagePath))
            {
                productImage.Image = Image.FromFile(imagePath);
            } else
            {
                productImage.Image = SystemIcons.Error.ToBitmap();
            }

            Label nameLabel = new Label
            {
                Text = $"Название: {name}",
                AutoSize = true,
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(10, 170)
            };

            Label priceLabel = new Label
            {
                Text = $"Цена: {price} ₽",
                AutoSize = true,
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(10, 200)
            };

            Label quantityLabel = new Label
            {
                Text = $"На складе: {quantity}",
                AutoSize = true,
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(10, 230)
            };

            Label selectQuantityLabel = new Label
            {
                Text = "Выберите кол-во:",
                AutoSize = true,
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(10, 260)
            };

            NumericUpDown quantitySelector = new NumericUpDown
            {
                Minimum = 1,
                Maximum = quantity,
                Value = 1,
                Location = new Point(160, 255),
                Size = new Size(70, 30),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            Button button = new Button
            {
                Text = "Добавить",
                BackColor = Color.White,
                ForeColor = Color.RoyalBlue,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(70, 300),
                Size = new Size(110, 30),
                Tag = new { Name = name, QuantityLabel = quantityLabel, QuantitySelector = quantitySelector }
            };

            button.FlatAppearance.BorderSize = 0;
            button.Click += AddToBasket;

            productPanel.Controls.Add(productImage);
            productPanel.Controls.Add(nameLabel);
            productPanel.Controls.Add(priceLabel);
            productPanel.Controls.Add(quantityLabel);
            productPanel.Controls.Add(selectQuantityLabel);
            productPanel.Controls.Add(quantitySelector);
            productPanel.Controls.Add(button);

            return productPanel;
        }

        private void AddToBasket (object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                dynamic tagData = button.Tag;
                string productName = tagData.Name;
                Label quantityLabel = tagData.QuantityLabel;
                NumericUpDown quantitySelector = tagData.QuantitySelector;

                int selectedQuantity = (int) quantitySelector.Value;

                if (productStock[productName] >= selectedQuantity)
                {
                    productStock[productName] -= selectedQuantity;
                    quantityLabel.Text = $"На складе: {productStock[productName]}";

                    // Добавление в корзину
                    using (StreamWriter writer = new StreamWriter("basket.txt", true))
                    {
                        writer.WriteLine($"{productName},{selectedQuantity}");
                    }

                    MessageBox.Show($"Товар '{productName}' ({selectedQuantity} шт.) добавлен в корзину.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBasket();
                } else
                {
                    MessageBox.Show($"Недостаточно товара '{productName}' на складе. Доступно: {productStock[productName]} шт.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void LoadBasket ()
        {
            flowLayoutPanel2.Controls.Clear();
            decimal totalPrice = 0;  // Для подсчета общей суммы покупки

            if (File.Exists("basket.txt"))
            {
                string[] basketItems = File.ReadAllLines("basket.txt");
                var groupedItems = basketItems.GroupBy(item => item.Split(',')[0])
                                              .Select(g => new {
                                                  Name = g.Key,
                                                  Quantity = g.Sum(item => int.Parse(item.Split(',')[1])),
                                                  Price = GetProductPrice(g.Key), // Получаем цену товара
                                                  ImagePath = GetProductImagePath(g.Key) // Получаем путь изображения товара
                                              });

                foreach (var item in groupedItems)
                {
                    Panel basketPanel = new Panel
                    {
                        BackColor = Color.RoyalBlue,
                        Size = new Size(250, 150),
                        Margin = new Padding(5),
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    // Картинка товара
                    PictureBox productImage = new PictureBox
                    {
                        Size = new Size(100, 100),
                        Location = new Point(10, 10),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    if (File.Exists(item.ImagePath))  // Проверяем, существует ли картинка
                    {
                        productImage.Image = Image.FromFile(item.ImagePath);
                    } else
                    {
                        productImage.Image = SystemIcons.Error.ToBitmap();  // Если картинка не найдена
                    }

                    // Название товара
                    Label nameLabel = new Label
                    {
                        Text = $"Название: {item.Name}",
                        AutoSize = true,
                        ForeColor = Color.White,
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        Location = new Point(120, 10)
                    };

                    // Количество товара
                    Label quantityLabel = new Label
                    {
                        Text = $"Кол-во: {item.Quantity}",
                        AutoSize = true,
                        ForeColor = Color.White,
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        Location = new Point(120, 40)
                    };

                    // Общая стоимость товара
                    decimal totalItemPrice = item.Quantity * item.Price;
                    Label priceLabel = new Label
                    {
                        Text = $"Цена: {totalItemPrice} ₽",
                        AutoSize = true,
                        ForeColor = Color.White,
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        Location = new Point(120, 70)
                    };

                    // Добавление картинок, текста и цены в панель
                    basketPanel.Controls.Add(productImage);
                    basketPanel.Controls.Add(nameLabel);
                    basketPanel.Controls.Add(quantityLabel);
                    basketPanel.Controls.Add(priceLabel);

                    flowLayoutPanel2.Controls.Add(basketPanel);

                    // Добавляем к общей стоимости
                    totalPrice += totalItemPrice;
                }

                // Добавляем общую сумму
                Label totalLabel = new Label
                {
                    Text = $"Общая сумма: {totalPrice} ₽",
                    AutoSize = true,
                    ForeColor = Color.White,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    Location = new Point(10, flowLayoutPanel2.Height + 10)
                };
                flowLayoutPanel2.Controls.Add(totalLabel);
            } else
            {
                MessageBox.Show("Корзина пуста.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Функция для получения цены товара из файла products.txt
        private decimal GetProductPrice (string productName)
        {
            string filePath = "products.txt";
            if (File.Exists(filePath))
            {
                string[] products = File.ReadAllLines(filePath);
                foreach (var product in products)
                {
                    string[] details = product.Split(',');
                    if (details.Length > 2 && details[1].Trim() == productName.Trim())
                    {
                        decimal price;
                        if (decimal.TryParse(details[2], out price))
                        {
                            return price;
                        }
                    }
                }
            }
            return 0;  // Если цена не найдена
        }

        // Функция для получения пути к изображению товара
        private string GetProductImagePath (string productName)
        {
            string filePath = "products.txt";
            if (File.Exists(filePath))
            {
                string[] products = File.ReadAllLines(filePath);
                foreach (var product in products)
                {
                    string[] details = product.Split(',');
                    if (details.Length > 2 && details[1].Trim() == productName.Trim())
                    {
                        return details[0];  // Путь к изображению
                    }
                }
            }
            return string.Empty;  // Если изображение не найдено
        }

        private string LoadUserName ()
        {
            string filePath = "User Data.txt";  // Путь к файлу
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath).Trim();  // Считываем имя из файла
            } else
            {
                MessageBox.Show("Не удалось найти файл с именем пользователя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Неизвестный пользователь";  // В случае ошибки возвращаем дефолтное имя
            }
        }
        private void DisplayUserProfile ()
        {
            string profileFilePath = "Profile.txt"; // Путь к файлу профиля
            if (File.Exists(profileFilePath))
            {
                string[] profileData = File.ReadAllLines(profileFilePath);
                if (profileData.Length > 0)
                {
                    string[] profileFields = profileData[0].Split(',');

                    // Извлекаем данные из профиля
                    string userName = profileFields[0].Trim();  // Имя пользователя
                    string imagePath = profileFields[1].Trim();  // Путь к изображению профиля
                    string productName = profileFields[2].Trim(); // Название товара
                    decimal totalPrice = decimal.Parse(profileFields[3].Trim()); // Сумма покупки
                    string purchaseStatus = profileFields[4].Trim(); // Статус покупки

                    // Приветствие с именем пользователя
                    Label greetingLabel = new Label
                    {
                        Text = $"Привет, {userName}!",
                        AutoSize = true,
                        ForeColor = Color.RoyalBlue,
                        Font = new Font("Arial", 14, FontStyle.Bold),
                        Location = new Point(10, 10)  // Расположение в верхней части формы
                    };

                    // Очищаем и обновляем панель с информацией о пользователе
                    flowLayoutPanel3.Controls.Clear();
                    flowLayoutPanel3.Controls.Add(greetingLabel);

                    // Изменение расположения блоков покупок ниже приветствия
                    flowLayoutPanel3.FlowDirection = FlowDirection.TopDown; // Располагаем элементы вертикально

                    // Добавляем блоки покупок
                    DisplayPurchases();
                } else
                {
                    MessageBox.Show("Ошибка при загрузке данных профиля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                MessageBox.Show("Файл профиля не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DisplayPurchases ()
        {
            string profileFilePath = "Profile.txt"; // Путь к файлу профиля
            if (File.Exists(profileFilePath))
            {
                string[] profileData = File.ReadAllLines(profileFilePath);
                foreach (var profileLine in profileData)
                {
                    string[] profileFields = profileLine.Split(',');

                    string productName = profileFields[2].Trim(); // Название товара
                    decimal totalPrice = decimal.Parse(profileFields[3].Trim()); // Сумма покупки
                    string purchaseStatus = profileFields[4].Trim(); // Статус покупки
                    string imagePath = profileFields[1].Trim(); // Путь к изображению

                    // Создаем панель для каждой покупки
                    Panel purchasePanel = new Panel
                    {
                        BackColor = Color.RoyalBlue,
                        Width = flowLayoutPanel3.Width - 20, // Устанавливаем ширину равной ширине панели, минус отступы
                        Margin = new Padding(5),
                        BorderStyle = BorderStyle.FixedSingle,
                        AutoSize = true, // Панель будет изменять свой размер в зависимости от содержимого
                        AutoSizeMode = AutoSizeMode.GrowAndShrink // Позволяет панели изменять размер по мере добавления элементов
                    };

                    // Картинка товара
                    PictureBox productImage = new PictureBox
                    {
                        Size = new Size(100, 100),
                        Location = new Point(10, 10),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    if (File.Exists(imagePath))
                    {
                        productImage.Image = Image.FromFile(imagePath);
                    } else
                    {
                        productImage.Image = SystemIcons.Information.ToBitmap(); // Если картинка не найдена
                    }

                    // Название товара
                    Label productLabel = new Label
                    {
                        Text = $"Товар: {productName}",
                        AutoSize = true,
                        ForeColor = Color.White,
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        Location = new Point(120, 10)
                    };

                    // Сумма покупки
                    Label priceLabel = new Label
                    {
                        Text = $"Цена: {totalPrice} ₽",
                        AutoSize = true,
                        ForeColor = Color.White,
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        Location = new Point(120, 40)
                    };

                    // Статус покупки
                    Label statusLabel = new Label
                    {
                        Text = $"Статус: {purchaseStatus}",
                        AutoSize = true,
                        ForeColor = Color.White,
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        Location = new Point(120, 70)
                    };

                    // Добавляем картинку, название, цену и статус на панель
                    purchasePanel.Controls.Add(productImage);
                    purchasePanel.Controls.Add(productLabel);
                    purchasePanel.Controls.Add(priceLabel);
                    purchasePanel.Controls.Add(statusLabel);

                    // Добавляем панель с покупкой на FlowLayoutPanel
                    flowLayoutPanel3.Controls.Add(purchasePanel);
                }
            } else
            {
                MessageBox.Show("Ошибка при загрузке данных о покупках.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}

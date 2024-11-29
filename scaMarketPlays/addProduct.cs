using System;
using System.IO;
using System.Windows.Forms;

namespace scaMarketPlays
{
    public partial class addProduct : Form
    {
        public addProduct()
        {
            InitializeComponent();
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Изображения (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp|Все файлы (*.*)|*.*",
                Title = "Выберите изображение"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtImagePath.Text = openFileDialog.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string imagePath = txtImagePath.Text;
            string productName = txtProductName.Text;
            string price = txtPrice.Text;
            string quantity = txtQuantity.Text;
            string manufacturer = txtManufacturer.Text;

            if (string.IsNullOrEmpty(imagePath) || string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(price) ||
                string.IsNullOrEmpty(quantity) || string.IsNullOrEmpty(manufacturer))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string data = $"{imagePath},{productName},{price},{quantity},{manufacturer}";

            string filePath = "products.txt";
            File.AppendAllLines(filePath, new[] { data });

            MessageBox.Show("Продукт успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
    }
}

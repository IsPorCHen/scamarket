using System.IO;
using System.Windows.Forms;
using System.Linq;
using static System.Windows.Forms.LinkLabel;
using System;

namespace scaMarketPlays
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            HidePanels(false);
            passwordSaleman.UseSystemPasswordChar = true;
            userPassword.UseSystemPasswordChar = true;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void HidePanels(bool enabled)
        {
            userLogin.Visible = enabled;
            userLogin.Enabled = enabled;
            userPassword.Visible = enabled;
            userPassword.Enabled = enabled;
            loginSaleman.Visible = enabled;
            loginSaleman.Enabled = enabled;
            passwordSaleman.Visible = enabled;
            passwordSaleman.Enabled = enabled;
            login.Visible = enabled;
            password.Visible = enabled;
        }

        private void SelectHide(bool enabled)
        {
            userLogin.Visible = enabled;
            userLogin.Enabled = enabled;
            userPassword.Visible = enabled;
            userPassword.Enabled = enabled;
            loginSaleman.Visible = !enabled;
            loginSaleman.Enabled = !enabled;
            passwordSaleman.Visible = !enabled;
            passwordSaleman.Enabled = !enabled;
        }

        private void userSelect_CheckedChanged(object sender, System.EventArgs e)
        {
            login.Visible = true;
            password.Visible = true;
            SelectHide(true);
        }

        private void selectSaleman_CheckedChanged(object sender, System.EventArgs e)
        {
            login.Visible = true;
            password.Visible = true;
            SelectHide(false);
        }

        private void loginButton_Click(object sender, System.EventArgs e)
        {
            if (selectSaleman.Checked)
            {
                if (passwordSaleman.Text != "" && loginSaleman.Text != "")
                {
                    if (CorrectPassword(passwordSaleman, loginSaleman))
                    {
                        string[] fileText = File.ReadAllLines("Saleman Data.txt");
                        int index = Array.FindIndex(fileText, str => str.Contains(loginSaleman.Text));

                        if (index != -1)
                        {
                            string stroke = File.ReadAllLines("Saleman Data.txt")[index];
                            string[] info = stroke.Split(':');

                            if (passwordSaleman.Text == info[1])
                            {
                                OpenSalemanForm();
                            }
                            else
                            {
                                MessageBox.Show("Неверный пароль");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Продавец не найдет");
                        }
                    }
                } else
                {
                    MessageBox.Show("Обнаружены пустые поля");
                }
            }
            else
            {
                if (userLogin.Text != "" && userPassword.Text != "")
                {
                    if (CorrectPassword(userPassword, userLogin))
                    {
                        string[] fileText = File.ReadAllLines("User Data.txt");
                        int index = Array.FindIndex(fileText, str => str.Contains(userLogin.Text));

                        if (index != -1)
                        {
                            string stroke = File.ReadAllLines("User Data.txt")[index];
                            string[] info = stroke.Split(':');

                            if (userPassword.Text == info[1])
                            {
                                OpenBuyer();
                            }
                            else
                            {
                                MessageBox.Show("Неверный пароль");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Покупатель не найдет");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Обнаружены пустые поля");
                }
            }
        }

        private void registrationButton_Click(object sender, System.EventArgs e)
        {
            if (selectSaleman.Checked)
            {
                if (passwordSaleman.Text != "" && loginSaleman.Text != "")
                {
                    if (CorrectPassword(passwordSaleman, loginSaleman))
                    {
                        string[] fileText = File.ReadAllLines("Saleman Data.txt");
                        int index = Array.FindIndex(fileText, str => str.Contains(loginSaleman.Text));

                        if (index == -1)
                        {
                            using (StreamWriter wr = File.AppendText("Saleman Data.txt"))
                            {
                                wr.WriteLine($"{loginSaleman.Text}:{passwordSaleman.Text}");
                            }

                            OpenSalemanForm();
                        }
                        else
                        {
                            MessageBox.Show("Продавец уже существует");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Обнаружены поля");
                }
            }
            else
            {
                if (userLogin.Text != "" && userPassword.Text != "")
                {
                    if (CorrectPassword(userPassword, userLogin))
                    {
                        string[] fileText = File.ReadAllLines("User Data.txt");
                        int index = Array.FindIndex(fileText, str => str.Contains(userLogin.Text));

                        if (index == -1)
                        {
                            using (StreamWriter wr = File.AppendText("User Data.txt"))
                            {
                                wr.WriteLine($"{userLogin.Text}:{userPassword.Text}");
                            }

                            OpenBuyer();
                        }
                        else
                        {
                            MessageBox.Show("Покупатель уже существует");
                        }
                    }
                }
            }
        }

        private void OpenSalemanForm()
        {
            SalemanForm form = new SalemanForm();
            this.Hide();
            form.Show();
        }

        private void OpenBuyer()
        {
            buyer b = new buyer();
            this.Hide();
            b.Show();
        }
        private bool CorrectPassword(TextBox password, TextBox login)
        {
            char[] specialSymbols = { '!', '№', '@', '%', ';', '?', ':' };
            bool contains = specialSymbols.Any(password.Text.Contains);

            if (password.Text.Length < 8)
            {
                MessageBox.Show("Длина пароля должна быть больше или равно 8");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(password.Text))
            {
                MessageBox.Show("Пароль не должен быть содержать пробел, или не должен быть пустым");
                return false;
            }
            else if (!contains)
            {
                MessageBox.Show("Пароль должен содержать спец сипволы");
                return false;
            }
            else if (!password.Text.Any(char.IsUpper) || !password.Text.Any(char.IsLower))
            {
                MessageBox.Show("Пароль должен содержать буквы разного ргистра");
                return false;
            }
            else if (password == login)
            {
                MessageBox.Show("Пароль не должен быть равен логину");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            passwordSaleman.UseSystemPasswordChar = !checkBox1.Checked;
            userPassword.UseSystemPasswordChar = !checkBox1.Checked;
        }
    }
}

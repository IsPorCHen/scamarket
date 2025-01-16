using System.Drawing;
using System.Windows.Forms;

namespace scaMarketPlays
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.userSelect = new System.Windows.Forms.RadioButton();
            this.selectSaleman = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.userLogin = new System.Windows.Forms.TextBox();
            this.userPassword = new System.Windows.Forms.TextBox();
            this.passwordSaleman = new System.Windows.Forms.TextBox();
            this.loginSaleman = new System.Windows.Forms.TextBox();
            this.login = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this.registrationButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // userSelect
            // 
            this.userSelect.AutoSize = true;
            this.userSelect.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.userSelect.ForeColor = System.Drawing.Color.RoyalBlue;
            this.userSelect.Location = new System.Drawing.Point(350, 130);
            this.userSelect.Margin = new System.Windows.Forms.Padding(4);
            this.userSelect.Name = "userSelect";
            this.userSelect.Size = new System.Drawing.Size(127, 23);
            this.userSelect.TabIndex = 0;
            this.userSelect.TabStop = true;
            this.userSelect.Text = "Покупатель";
            this.userSelect.UseVisualStyleBackColor = true;
            this.userSelect.CheckedChanged += new System.EventHandler(this.userSelect_CheckedChanged);
            // 
            // selectSaleman
            // 
            this.selectSaleman.AutoSize = true;
            this.selectSaleman.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.selectSaleman.ForeColor = System.Drawing.Color.RoyalBlue;
            this.selectSaleman.Location = new System.Drawing.Point(350, 160);
            this.selectSaleman.Margin = new System.Windows.Forms.Padding(4);
            this.selectSaleman.Name = "selectSaleman";
            this.selectSaleman.Size = new System.Drawing.Size(111, 23);
            this.selectSaleman.TabIndex = 1;
            this.selectSaleman.TabStop = true;
            this.selectSaleman.Text = "Продавец";
            this.selectSaleman.UseVisualStyleBackColor = true;
            this.selectSaleman.CheckedChanged += new System.EventHandler(this.selectSaleman_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(335, 114);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите роль:";
            // 
            // userLogin
            // 
            this.userLogin.Location = new System.Drawing.Point(305, 204);
            this.userLogin.Margin = new System.Windows.Forms.Padding(4);
            this.userLogin.Name = "userLogin";
            this.userLogin.Size = new System.Drawing.Size(200, 25);
            this.userLogin.TabIndex = 3;
            // 
            // userPassword
            // 
            this.userPassword.Location = new System.Drawing.Point(305, 254);
            this.userPassword.Margin = new System.Windows.Forms.Padding(4);
            this.userPassword.Name = "userPassword";
            this.userPassword.Size = new System.Drawing.Size(200, 25);
            this.userPassword.TabIndex = 4;
            // 
            // passwordSaleman
            // 
            this.passwordSaleman.Location = new System.Drawing.Point(305, 254);
            this.passwordSaleman.Margin = new System.Windows.Forms.Padding(4);
            this.passwordSaleman.Name = "passwordSaleman";
            this.passwordSaleman.Size = new System.Drawing.Size(202, 25);
            this.passwordSaleman.TabIndex = 6;
            // 
            // loginSaleman
            // 
            this.loginSaleman.Location = new System.Drawing.Point(305, 204);
            this.loginSaleman.Margin = new System.Windows.Forms.Padding(4);
            this.loginSaleman.Name = "loginSaleman";
            this.loginSaleman.Size = new System.Drawing.Size(200, 25);
            this.loginSaleman.TabIndex = 5;
            // 
            // login
            // 
            this.login.AutoSize = true;
            this.login.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.login.ForeColor = System.Drawing.Color.RoyalBlue;
            this.login.Location = new System.Drawing.Point(244, 210);
            this.login.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(58, 19);
            this.login.TabIndex = 7;
            this.login.Text = "Логин";
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.password.ForeColor = System.Drawing.Color.RoyalBlue;
            this.password.Location = new System.Drawing.Point(231, 256);
            this.password.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(71, 19);
            this.password.TabIndex = 8;
            this.password.Text = "Пароль";
            // 
            // registrationButton
            // 
            this.registrationButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.registrationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registrationButton.ForeColor = System.Drawing.Color.White;
            this.registrationButton.Location = new System.Drawing.Point(305, 304);
            this.registrationButton.Margin = new System.Windows.Forms.Padding(4);
            this.registrationButton.Name = "registrationButton";
            this.registrationButton.Size = new System.Drawing.Size(174, 28);
            this.registrationButton.TabIndex = 10;
            this.registrationButton.Text = "Зарегистрироваться";
            this.registrationButton.UseVisualStyleBackColor = false;
            this.registrationButton.Click += new System.EventHandler(this.registrationButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(302, 283);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Уже есть аккаунт?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(470, 285);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "Войти";
            this.label3.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(300, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.checkBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.checkBox1.Location = new System.Drawing.Point(515, 254);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(171, 23);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "Показать пароль";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.registrationButton);
            this.Controls.Add(this.password);
            this.Controls.Add(this.login);
            this.Controls.Add(this.passwordSaleman);
            this.Controls.Add(this.loginSaleman);
            this.Controls.Add(this.userPassword);
            this.Controls.Add(this.userLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectSaleman);
            this.Controls.Add(this.userSelect);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Авторзация";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton userSelect;
        private System.Windows.Forms.RadioButton selectSaleman;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userLogin;
        private System.Windows.Forms.TextBox userPassword;
        private System.Windows.Forms.TextBox passwordSaleman;
        private System.Windows.Forms.TextBox loginSaleman;
        private System.Windows.Forms.Label login;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.Button registrationButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}


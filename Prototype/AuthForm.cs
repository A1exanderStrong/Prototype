using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace Prototype
{
    public partial class AuthForm : Form
    {
        bool isPasswordVisible = true;
        public AuthForm()
        {
            InitializeComponent();
            togglePassword();
        }

        private void togglePassword()
        {
            txtPassword.UseSystemPasswordChar = !isPasswordVisible;
            if (isPasswordVisible) 
            { 
                pictureBox1.ImageLocation = "../../icons/hidden.png";
            }
            else { pictureBox1.ImageLocation = "../../icons/eye.png"; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkFields()) { std.error("Не все поля заполнены!"); return; }
            if (!Connection.Test()) { std.error("Ошибка подключения"); return; }

            var activeUser = Connection.Auth(txtLogin.Text, txtPassword.Text);
            if (activeUser == null) { std.error("Неверно указаны логин или пароль"); return; }
            AppData.ActiveUser = activeUser;

            Hide();
            new MainMenu().ShowDialog();
        }

        private bool checkFields()
        {
            return !txtLogin.Equals(string.Empty) && !txtPassword.Equals(string.Empty);
        }

        private void AuthForm_FormClosing(object sender, FormClosingEventArgs e) => std.AppExit(e);

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            togglePassword();
        }
    }
}

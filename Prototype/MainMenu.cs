using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prototype.Entities;

namespace Prototype
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            new AuthForm().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            new StuffForm().ShowDialog();
        }

        private void buttonSendResource_Click(object sender, EventArgs e)
        {
            new ResourceForm().ShowDialog();
        }

        private void buttonResourcesOnRequest_Click(object sender, EventArgs e)
        {
            Hide();
            new CheckResourcesForm().ShowDialog();
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            std.AppExit(e);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            switch (AppData.ActiveUser.RoleId) 
            {
                case User.ADMIN:
                    {
                        btnSendResource.Visible = false;
                        btnResourcesOnRequest.Visible = false;
                        btnResourcesOwned.Visible = false;
                        break;
                    }
                case User.MANAGER:
                    {
                        buttonUsers.Visible = false;
                        btnSendResource.Visible = false;
                        btnResourcesOwned.Visible = false;
                        break;
                    }
                case User.USER:
                    {
                        buttonUsers.Visible = false;
                        btnSalesReport.Visible = false;
                        btnResourcesOnRequest.Visible = false;
                        break;
                    }
            }
            resizeForm(AppData.ActiveUser.RoleId);
        }

        private void resizeForm(int role)
        {
            // second button pos - 78, 116
            // third button pos - 78, 159

            // form size +60 for each button
            // btnBack pos = form size - 90

            if (role == User.ADMIN)
            {
                buttonUsers.Location = new Point(78, 116);
                btnBack.Location = new Point(78, 190);
                Size = new Size(423, 280);
            }
            if (role == User.MANAGER)
            {
                btnResourcesOnRequest.Location = new Point(78, 159);
                btnHandbook.Location = new Point(78, 202);
                btnBack.Location = new Point(78, 310);
                Size = new Size(423, 400);
            }
            if (role == User.USER)
            {
                btnSendResource.Location = new Point(78, 116);
                btnResourcesOwned.Location = new Point(78, 159);
                btnBack.Location = new Point(78, 250);
                Size = new Size(423, 340);
            }
        }

        private void buttonUsers_Click(object sender, EventArgs e)
        {
            Hide();
            new UsersForm().ShowDialog();
        }

        private void btnHandbook_Click(object sender, EventArgs e)
        {
            Hide();
            new HandbooksForm().ShowDialog();
        }
    }
}

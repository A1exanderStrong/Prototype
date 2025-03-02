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
using Prototype.Entities.Handbooks;

namespace Prototype
{
    public partial class UsersForm : Form
    {
        private const int rowsHeight = 100;
        private const int chunckSize = 20; // количество отображаемых ресурсов
        private int offset = 0;

        List<User> users = new List<User>();
        List<Role> roles = new List<Role>();

        #region search params
        private string _name = "";
        private int _role = 0;
        private string _sort = "";
        private bool sort_reversed = false;
        #endregion

        private readonly float users_update_delay = 0.5f; // в секундах
        private const int maxRequests = 20; // Максимальное количество попыток обновления списка ресурсов

        public UsersForm()
        {
            InitializeComponent();
            ReloadPage();
            loaderImage.ImageLocation = "https://i.gifer.com/origin/b4/b4d657e7ef262b88eb5f7ac021edda87.gif";
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Hide();
            new MainMenu().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            createColumns();

            roles = Connection.GetRoles();
            ComboBoxRoles.Items.Add("Все пользователи");
            ComboBoxRoles.SelectedIndex = 0;
            comboBoxSort.SelectedIndex = 0;
            foreach (var role in roles)
                ComboBoxRoles.Items.Add(role.Name);
        }

        private async void ReloadPage()
        {
            users.Clear();
            labelUsersNotFound.Visible = false;

            //users = await Connection.GetUsers(_name, _role, _sort, chunckSize, offset, sort_reversed);
            loaderImage.Visible = true;

            var request = Connection.GetUsers(_name, _role, _sort, chunckSize, offset, sort_reversed);
            for (int i = 0; i < maxRequests; i++)
            {
                await request;
                if (request.IsCompleted)
                {
                    users = request.Result;
                    loaderImage.Visible = false;
                    updateRows();
                    return;
                }
                //await Task.Delay((int)(1000 * users_update_delay));
            }
            loaderImage.Visible = false;
            labelUsersNotFound.Visible = true;
        }

        private void createColumns()
        {
            // login | name | email | role | registartion_date

            var login = new DataGridViewTextBoxColumn
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                HeaderText = "Логин"
            };
            var name = new DataGridViewTextBoxColumn
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                HeaderText = "Имя пользователя"
            };
            var email = new DataGridViewTextBoxColumn
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                HeaderText = "email"
            };
            var role = new DataGridViewTextBoxColumn
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                HeaderText = "Роль"
            };
            var registration_date = new DataGridViewTextBoxColumn
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader,
                HeaderText = "Дата регистрации",
            };

            dgv.Columns.Add(login);
            dgv.Columns.Add(name);
            dgv.Columns.Add(email);
            dgv.Columns.Add(role);
            dgv.Columns.Add(registration_date);
        }

        private void updateRows()
        {
            if (dgv.ColumnCount == 0) return;
            dgv.Rows.Clear();
            dgv.RowTemplate.Height = rowsHeight;
            // login | _name | email | role | registartion_date
            foreach (User user in users)
            {
                dgv.Rows.Add(user.Login, 
                    user.Name,
                    user.Email,
                    user.GetRole(),
                    user.GetRegistrationDate());
            }
            List<Entity> entities = std.ConvertToEntity(users);
            txtUserLogin.AutoCompleteCustomSource = std.UpdateAutoCompleteSource(entities);
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            _name = txtUserLogin.Text;
            if (_name.Length >= 3 || _name.Length == 0) ReloadPage();
        }

        private void UsersForm_FormClosing(object sender, FormClosingEventArgs e) => std.AppExit(e);

        private void ComboBoxRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxRoles.SelectedIndex < 0) return;
            if (ComboBoxRoles.SelectedIndex == 0) { _role = 0; ReloadPage(); return; }

            foreach (var role in roles)
            {
                if (role.Name == ComboBoxRoles.SelectedItem.ToString())
                {
                    _role = role.Id;
                    break;
                }
            }
            ReloadPage();
        }

        private void comboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSort.SelectedIndex == 0) { _sort = ""; ReloadPage(); return; }
            sort_reversed = comboBoxSort.SelectedIndex == 1;
            _sort = "registration_date";
            ReloadPage();
        }
    }
}

using Prototype.Entities;
using Prototype.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prototype.Entities.Handbooks;

namespace Prototype
{
    public partial class HandbooksForm : Form
    {
        private string[] handbooksList = new string[] { "Выберите справочник", 
                                                        "Категории", 
                                                        "Роли" };
        private int rowsHeight = 30;

        public HandbooksForm()
        {
            InitializeComponent();
        }

        private void HandbooksForm_FormClosing(object sender, FormClosingEventArgs e) => std.AppExit(e);

        private void HandbooksForm_Load(object sender, EventArgs e)
        {
            comboBoxHandbooks.Items.AddRange(handbooksList);
            comboBoxHandbooks.SelectedIndex = 0;

            createColumns();
            updateRows();
        }

        private void createColumns()
        {
            var namecol = new DataGridViewTextBoxColumn
            {
                Name = "Наименование",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            dgv.Columns.Add(namecol);
        }

        private string GetSelectedHandbook()
        {
            if (comboBoxHandbooks.SelectedIndex == 1) { return "categories"; }
            if (comboBoxHandbooks.SelectedIndex == 2) { return "roles"; }
            return "none";
        }

        private void updateRows()
        {
            dgv.Rows.Clear();
            dgv.RowTemplate.Height = rowsHeight;
            if (GetSelectedHandbook() == "none") return;

            var handbook = Connection.GetHandbookData(GetSelectedHandbook());
            foreach (var item in handbook)
                dgv.Rows.Add(item.Name);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            new MainMenu().ShowDialog();
        }

        private void comboBoxHandbooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateRows();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip cm = new ContextMenuStrip();
                var add = cm.Items.Add("Добавить");
                var edit = cm.Items.Add("Редактировать");
                cm.Show(dgv, dgv.PointToClient(MousePosition));

                edit.Click += new EventHandler(btnEdit_Click);
                add.Click += new EventHandler(btnAdd_Click);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            std.info($"{dgv.SelectedRows.Count}");
            var temp = dgv.SelectedRows[0].Cells["Наименование"].Value.ToString();
            new AddEditHandbook(GetSelectedHandbook(), 0, temp).ShowDialog();
            updateRows();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new AddEditHandbook(GetSelectedHandbook(), 1).ShowDialog();
            updateRows();
        }
    }
}

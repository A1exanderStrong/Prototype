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
        private string[] handbooksList = new string[] { "Категории", 
                                                        "Роли" };
        private int rowsHeight = 30;
        private List<Handbook> handbook_data;

        public HandbooksForm()
        {
            InitializeComponent();
        }

        private void HandbooksForm_FormClosing(object sender, FormClosingEventArgs e) => std.AppExit(e);

        private void HandbooksForm_Load(object sender, EventArgs e)
        {            
            createColumns();

            comboBoxHandbooks.Items.AddRange(handbooksList);
            comboBoxHandbooks.SelectedIndex = 0;

            updateRows();
        }

        private void createColumns()
        {
            var namecol = new DataGridViewTextBoxColumn
            {
                Name = " ",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            dgv.Columns.Add(namecol);
        }

        private string GetSelectedHandbook()
        {
            if (comboBoxHandbooks.SelectedIndex == 0) { return "categories"; }
            if (comboBoxHandbooks.SelectedIndex == 1) { return "roles"; }
            return "none";
        }

        private void updateRows()
        {
            dgv.Rows.Clear();
            dgv.RowTemplate.Height = rowsHeight;
            if (GetSelectedHandbook() == "none") return;
            
            handbook_data = Connection.GetHandbookData(GetSelectedHandbook());
            foreach (var item in handbook_data)
                dgv.Rows.Add(item.Name);

            updateAutoCompleteSource();
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

        private void updateAutoCompleteSource()
        {
            var source = new AutoCompleteStringCollection();
            foreach (Handbook item in handbook_data)
            {
                var suggestionBundle = "";
                foreach (string word in item.Name.Split(' '))
                {
                    suggestionBundle += $"{word}";
                    if (source.Contains(suggestionBundle)) continue;
                    source.Add(suggestionBundle);
                    suggestionBundle += " ";
                }
            }
            txtName.AutoCompleteCustomSource = source;
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
            var temp = dgv.SelectedRows[0].Cells[" "].Value.ToString();
            Handbook selectedHandbook = Connection.GetHandbookItem(GetSelectedHandbook(), temp);
            new AddEditHandbook(GetSelectedHandbook(), 0, selectedHandbook).ShowDialog();
            updateRows();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new AddEditHandbook(GetSelectedHandbook(), 1).ShowDialog();
            updateRows();
        }
    }
}

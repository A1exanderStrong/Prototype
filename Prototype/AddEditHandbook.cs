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
    public partial class AddEditHandbook : Form
    {
        private string[] modes = { "edit", "add" };
        private int activeMode = 0;
        private string table = "";
        private Handbook activeHandbook;

        /// <summary>
        /// Добавляет или редактирует в зависимости от режима запись в справочнике. 0 - режим редактирования, 1 - режим добавления
        /// </summary>
        /// <param name="handbook"></param>
        /// <param name="mode"></param>
        public AddEditHandbook(string table, int mode, Handbook hbook = null)
        {
            InitializeComponent();
            this.table = table;
            activeMode = mode;
            activeHandbook = hbook;
        }

        private void btnAddApply_Click(object sender, EventArgs e)
        {
            switch (modes[activeMode]) 
            {
                case "edit":
                    if (activeHandbook == null) { std.error("При получении объекта справочника возникла ошибка."); return; }
                    activeHandbook.Name = txtName.Text;
                    Connection.UpdateHandbookItem(table, activeHandbook);
                    std.info("Запись успешно обновлена");
                    Close();
                    break;
                case "add":
                    Connection.CreateHandbookItem(table, new Handbook { Name = txtName.Text });
                    std.info("Запись успешно создана");
                    Close();
                    break;
            }
        }

        private void AddEditHandbook_Load(object sender, EventArgs e)
        {
            txtName.Text = activeHandbook == null ? "" : activeHandbook.Name;
            if (modes[activeMode] == "edit") btnAddApply.Text = "Применить";
            if (modes[activeMode] == "add") btnAddApply.Text = "Добавить";
        }
    }
}

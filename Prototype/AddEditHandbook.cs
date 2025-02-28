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
        private string activeHandbook = "";
        private string activeName = "";

        /// <summary>
        /// Добавляет или редактирует в зависимости от режима запись в справочнике. 0 - режим редактирования, 1 - режим добавления
        /// </summary>
        /// <param name="handbook"></param>
        /// <param name="mode"></param>
        public AddEditHandbook(string handbook, int mode, string name = "")
        {
            InitializeComponent();
            activeHandbook = handbook;
            activeMode = mode;
            activeName = name;
        }

        private void btnAddApply_Click(object sender, EventArgs e)
        {
            switch (modes[activeMode]) 
            {
                case "edit":
                    Connection.UpdateHandbookItem(activeHandbook, new Handbook { Name = txtName.Text });
                    std.info("Запись успешно обновлена");
                    Close();
                    break;
                case "add":
                    Connection.CreateHandbookItem(activeHandbook, new Handbook { Name = txtName.Text });
                    std.info("Запись успешно создана");
                    Close();
                    break;
            }
        }

        private void AddEditHandbook_Load(object sender, EventArgs e)
        {
            txtName.Text = activeName;
            if (modes[activeMode] == "edit") btnAddApply.Text = "Применить";
            if (modes[activeMode] == "add") btnAddApply.Text = "Добавить";
        }
    }
}

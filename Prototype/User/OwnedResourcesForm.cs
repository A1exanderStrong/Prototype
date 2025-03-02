using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Prototype.Entities;
using Prototype.Entities.Handbooks;

namespace Prototype
{
    public partial class OwnedResourcesForm : Form
    {
        private const int rowsHeight = 100;
        private const int chunckSize = 20; // количество отображаемых ресурсов
        private int offset = 0;
        //private readonly static long resourcesCount = Connection.GetRecordsCount("resources");
        //private static int totalPages = std.CountPages(chunckSize, (int)resourcesCount);

        private bool canReloadPage = true;
      
        List<Resource> resources = new List<Resource>();
        List<Category> categories = new List<Category>();

        #region search params
        private string name = "";
        private string filter = "";
        private string sort = "";
        private bool sort_reversed = false;
        #endregion

        private float resources_update_delay = 0.5f; // в секундах
        private const int maxRequests = 20; // Максимальное количество попыток обновления списка ресурсов

        public OwnedResourcesForm()
        {
            InitializeComponent();
            ReloadPage();
            loaderImage.ImageLocation = "https://i.gifer.com/origin/b4/b4d657e7ef262b88eb5f7ac021edda87.gif";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            new MainMenu().ShowDialog();
        }

        private void StuffForm_Load(object sender, EventArgs e)
        {
            createColumns();

            categories = Connection.GetCategories();
            ComboBoxCategories.Items.Add("Все ресурсы");
            ComboBoxCategories.SelectedIndex = 0;
            comboBoxSort.SelectedIndex = 0;
            foreach(var category in categories)
                ComboBoxCategories.Items.Add(category.Name);
        }

        private void updateAutoCompleteSource()
        {
            var source = new AutoCompleteStringCollection();
            foreach (var resource in resources)
            {
                var suggestionBundle = "";
                foreach (string word in resource.Name.Split(' '))
                {
                    suggestionBundle += $"{word}";
                    if (source.Contains(suggestionBundle)) continue;
                    source.Add(suggestionBundle);
                    suggestionBundle += " ";
                }
                source.AddRange(resource.Name.Split(' '));
            }
            txtResourceName.AutoCompleteCustomSource = source;
        }

        private async void ReloadPage()
        {
            resources.Clear();
            labelResourcesNotFound.Visible = false;

            //resources = await Connection.GetOwningResources(name, filter, sort, chunckSize, offset, sort_reversed);
            loaderImage.Visible = true;
            var request = Connection.GetResources(name, filter, sort, chunckSize, offset, sort_reversed, AppData.ActiveUser.Id);

            for (int i = 0; i < maxRequests; i++)
            {
                await request;
                resources = request.Result;
                if (request.IsCompleted)
                {
                    updateRows();
                    loaderImage.Visible = false;
                    return;
                }
            }
            loaderImage.Visible = false; 
            labelResourcesNotFound.Visible = true;
        }

        private void createColumns()
        {
            // picture | name | category | price | author

            var name = new DataGridViewTextBoxColumn
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                HeaderText = "Наименование"
            };
            var category = new DataGridViewTextBoxColumn
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                HeaderText = "Категория"
            };
            var price = new DataGridViewTextBoxColumn
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                HeaderText = "Цена"
            };
            var picture = new DataGridViewImageColumn
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader,
                HeaderText = "Изображение",
                Width = 100,
                ImageLayout = DataGridViewImageCellLayout.Zoom
            };
            var author = new DataGridViewTextBoxColumn
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                HeaderText = "Автор"
            };

            dgv.Columns.Add(picture);
            dgv.Columns.Add(name);
            dgv.Columns.Add(category);
            dgv.Columns.Add(price);
            dgv.Columns.Add(author);
        }

        private void updateRows()
        {
            dgv.Rows.Clear();
            dgv.RowTemplate.Height = rowsHeight;
            // picture | name | category | price | author
            foreach (Resource resource in resources) 
            {
                dgv.Rows.Add(resource.Picture,
                            resource.Name,
                            resource.GetCategoryName(),
                            resource.Price,
                            resource.GetAuthor().Login);
            }
            updateAutoCompleteSource();
        }

        private void txtResourceName_TextChanged(object sender, EventArgs e)
        {
            if (canReloadPage)
            {
                name = txtResourceName.Text;
                if (name.Length >= 3 || name.Length == 0) ReloadPage();
            }
        }

        private void StuffForm_FormClosing(object sender, FormClosingEventArgs e) => std.AppExit(e);

        private void ComboBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxCategories.SelectedIndex < 0) return;
            if (ComboBoxCategories.SelectedIndex == 0) { filter = ""; ReloadPage(); return; }

            foreach (var category in categories)
            {
                if (category.Name == ComboBoxCategories.SelectedItem.ToString())
                { 
                    filter = category.Id.ToString();
                    break;
                }
            }
            ReloadPage();
        }

        private void comboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSort.SelectedIndex == 0) { sort = ""; ReloadPage(); return; }
            sort_reversed = comboBoxSort.SelectedIndex == 1;
            sort = "publication_date";
            ReloadPage();
        }
    }
}

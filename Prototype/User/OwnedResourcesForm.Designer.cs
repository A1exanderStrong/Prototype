
namespace Prototype
{
    partial class OwnedResourcesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.txtResourceName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboBoxCategories = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.loaderImage = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxSort = new System.Windows.Forms.ComboBox();
            this.labelResourcesNotFound = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaderImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(313, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Приобретённые ресурсы";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(12, 32);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(833, 474);
            this.dgv.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 596);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 37);
            this.button1.TabIndex = 7;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtResourceName
            // 
            this.txtResourceName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtResourceName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtResourceName.Location = new System.Drawing.Point(144, 517);
            this.txtResourceName.MaxLength = 150;
            this.txtResourceName.Name = "txtResourceName";
            this.txtResourceName.Size = new System.Drawing.Size(701, 26);
            this.txtResourceName.TabIndex = 8;
            this.txtResourceName.TextChanged += new System.EventHandler(this.txtResourceName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 520);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Наименование:";
            // 
            // ComboBoxCategories
            // 
            this.ComboBoxCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxCategories.FormattingEnabled = true;
            this.ComboBoxCategories.Location = new System.Drawing.Point(144, 549);
            this.ComboBoxCategories.Name = "ComboBoxCategories";
            this.ComboBoxCategories.Size = new System.Drawing.Size(249, 28);
            this.ComboBoxCategories.TabIndex = 10;
            this.ComboBoxCategories.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCategories_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 552);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Категория: ";
            // 
            // loaderImage
            // 
            this.loaderImage.ImageLocation = "";
            this.loaderImage.Location = new System.Drawing.Point(384, 248);
            this.loaderImage.Name = "loaderImage";
            this.loaderImage.Size = new System.Drawing.Size(64, 57);
            this.loaderImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.loaderImage.TabIndex = 15;
            this.loaderImage.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(482, 552);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Сортировка: ";
            // 
            // comboBoxSort
            // 
            this.comboBoxSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSort.FormattingEnabled = true;
            this.comboBoxSort.Items.AddRange(new object[] {
            "Нет",
            "Сначала новые",
            "Сначала старые"});
            this.comboBoxSort.Location = new System.Drawing.Point(596, 549);
            this.comboBoxSort.Name = "comboBoxSort";
            this.comboBoxSort.Size = new System.Drawing.Size(249, 28);
            this.comboBoxSort.TabIndex = 16;
            this.comboBoxSort.SelectedIndexChanged += new System.EventHandler(this.comboBoxSort_SelectedIndexChanged);
            // 
            // labelResourcesNotFound
            // 
            this.labelResourcesNotFound.AutoSize = true;
            this.labelResourcesNotFound.Location = new System.Drawing.Point(368, 225);
            this.labelResourcesNotFound.Name = "labelResourcesNotFound";
            this.labelResourcesNotFound.Size = new System.Drawing.Size(111, 20);
            this.labelResourcesNotFound.TabIndex = 18;
            this.labelResourcesNotFound.Text = "Нет ресурсов";
            this.labelResourcesNotFound.Visible = false;
            // 
            // OwnedResourcesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 643);
            this.Controls.Add(this.labelResourcesNotFound);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxSort);
            this.Controls.Add(this.loaderImage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ComboBoxCategories);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtResourceName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OwnedResourcesForm";
            this.Text = "Ваши приобретённые ресурсы";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StuffForm_FormClosing);
            this.Load += new System.EventHandler(this.StuffForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaderImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtResourceName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboBoxCategories;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.PictureBox loaderImage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxSort;
        private System.Windows.Forms.Label labelResourcesNotFound;
    }
}
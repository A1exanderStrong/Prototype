
namespace Prototype
{
    partial class UsersForm
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
            this.txtUserLogin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboBoxRoles = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.loaderImage = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxSort = new System.Windows.Forms.ComboBox();
            this.labelUsersNotFound = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaderImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(390, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Пользователи";
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
            this.button1.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // txtUserLogin
            // 
            this.txtUserLogin.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtUserLogin.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtUserLogin.Location = new System.Drawing.Point(144, 517);
            this.txtUserLogin.MaxLength = 150;
            this.txtUserLogin.Name = "txtUserLogin";
            this.txtUserLogin.Size = new System.Drawing.Size(701, 26);
            this.txtUserLogin.TabIndex = 8;
            this.txtUserLogin.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 520);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Логин:";
            // 
            // ComboBoxRoles
            // 
            this.ComboBoxRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxRoles.FormattingEnabled = true;
            this.ComboBoxRoles.Location = new System.Drawing.Point(144, 549);
            this.ComboBoxRoles.Name = "ComboBoxRoles";
            this.ComboBoxRoles.Size = new System.Drawing.Size(249, 28);
            this.ComboBoxRoles.TabIndex = 10;
            this.ComboBoxRoles.SelectedIndexChanged += new System.EventHandler(this.ComboBoxRoles_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 552);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Роль: ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(688, 596);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 37);
            this.button2.TabIndex = 12;
            this.button2.Text = "В корзину";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(525, 596);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(157, 37);
            this.button3.TabIndex = 13;
            this.button3.Text = "Редактировать";
            this.button3.UseVisualStyleBackColor = true;
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
            // labelUsersNotFound
            // 
            this.labelUsersNotFound.AutoSize = true;
            this.labelUsersNotFound.Location = new System.Drawing.Point(380, 225);
            this.labelUsersNotFound.Name = "labelUsersNotFound";
            this.labelUsersNotFound.Size = new System.Drawing.Size(161, 20);
            this.labelUsersNotFound.TabIndex = 18;
            this.labelUsersNotFound.Text = "Нет пользователей";
            this.labelUsersNotFound.Visible = false;
            // 
            // UsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 643);
            this.Controls.Add(this.labelUsersNotFound);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxSort);
            this.Controls.Add(this.loaderImage);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ComboBoxRoles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUserLogin);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UsersForm";
            this.Text = "UsersForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UsersForm_FormClosing);
            this.Load += new System.EventHandler(this.UsersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaderImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtUserLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboBoxRoles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.PictureBox loaderImage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxSort;
        private System.Windows.Forms.Label labelUsersNotFound;
    }
}
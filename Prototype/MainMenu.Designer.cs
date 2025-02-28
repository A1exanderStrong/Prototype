
namespace Prototype
{
    partial class MainMenu
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
            this.btnBack = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSalesReport = new System.Windows.Forms.Button();
            this.buttonUsers = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSendResource = new System.Windows.Forms.Button();
            this.btnResourcesOnRequest = new System.Windows.Forms.Button();
            this.btnResourcesOwned = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(78, 354);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(249, 37);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(78, 73);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(249, 37);
            this.button2.TabIndex = 7;
            this.button2.Text = "Ресурсы";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSalesReport
            // 
            this.btnSalesReport.Location = new System.Drawing.Point(78, 116);
            this.btnSalesReport.Name = "btnSalesReport";
            this.btnSalesReport.Size = new System.Drawing.Size(249, 37);
            this.btnSalesReport.TabIndex = 8;
            this.btnSalesReport.Text = "Отчёт по продажам";
            this.btnSalesReport.UseVisualStyleBackColor = true;
            // 
            // buttonUsers
            // 
            this.buttonUsers.Location = new System.Drawing.Point(78, 159);
            this.buttonUsers.Name = "buttonUsers";
            this.buttonUsers.Size = new System.Drawing.Size(249, 37);
            this.buttonUsers.TabIndex = 10;
            this.buttonUsers.Text = "Пользователи";
            this.buttonUsers.UseVisualStyleBackColor = true;
            this.buttonUsers.Click += new System.EventHandler(this.buttonUsers_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Главное меню";
            // 
            // btnSendResource
            // 
            this.btnSendResource.Location = new System.Drawing.Point(78, 202);
            this.btnSendResource.Name = "btnSendResource";
            this.btnSendResource.Size = new System.Drawing.Size(249, 37);
            this.btnSendResource.TabIndex = 12;
            this.btnSendResource.Text = "Отправить ресурс";
            this.btnSendResource.UseVisualStyleBackColor = true;
            this.btnSendResource.Click += new System.EventHandler(this.buttonSendResource_Click);
            // 
            // btnResourcesOnRequest
            // 
            this.btnResourcesOnRequest.Location = new System.Drawing.Point(78, 245);
            this.btnResourcesOnRequest.Name = "btnResourcesOnRequest";
            this.btnResourcesOnRequest.Size = new System.Drawing.Size(249, 37);
            this.btnResourcesOnRequest.TabIndex = 13;
            this.btnResourcesOnRequest.Text = "Ресурсы на рассмотрении";
            this.btnResourcesOnRequest.UseVisualStyleBackColor = true;
            this.btnResourcesOnRequest.Click += new System.EventHandler(this.buttonResourcesOnRequest_Click);
            // 
            // btnResourcesOwned
            // 
            this.btnResourcesOwned.Location = new System.Drawing.Point(78, 288);
            this.btnResourcesOwned.Name = "btnResourcesOwned";
            this.btnResourcesOwned.Size = new System.Drawing.Size(249, 37);
            this.btnResourcesOwned.TabIndex = 14;
            this.btnResourcesOwned.Text = "Приобретённые ресурсы";
            this.btnResourcesOwned.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 401);
            this.Controls.Add(this.btnResourcesOwned);
            this.Controls.Add(this.btnResourcesOnRequest);
            this.Controls.Add(this.btnSendResource);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonUsers);
            this.Controls.Add(this.btnSalesReport);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnBack);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenu_FormClosing);
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSalesReport;
        private System.Windows.Forms.Button buttonUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSendResource;
        private System.Windows.Forms.Button btnResourcesOnRequest;
        private System.Windows.Forms.Button btnResourcesOwned;
    }
}
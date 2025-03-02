using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype
{
    partial class placeholder : TextBox
    {
        private readonly System.Drawing.Color DefaultColor;
        public string PlaceHolderText { get; set; }
        public placeholder(string init_text)
        {
            DefaultColor = ForeColor;

            GotFocus += (object sender, EventArgs e) =>
            {
                if (Text == PlaceHolderText) Text = string.Empty;
                ForeColor = DefaultColor;
            };

            LostFocus += (object sender, EventArgs e) => {
                if (string.IsNullOrEmpty(Text) || Text == PlaceHolderText)
                {
                    ForeColor = System.Drawing.Color.Gray;
                    Text = PlaceHolderText;
                    return;
                }

                ForeColor = DefaultColor;
            };

            if (!string.IsNullOrEmpty(init_text))
            {
                ForeColor = System.Drawing.Color.Gray;

                PlaceHolderText = init_text;
                Text = init_text;
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // placeholder
            // 
            this.Text = "9";
            this.ResumeLayout(false);

        }
    }
}

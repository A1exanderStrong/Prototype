using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class placeholder : System.Windows.Forms.TextBox
    {
        private readonly System.Drawing.Color DefaultColor;
        public string PlaceHolderText { get; set; }
        public placeholder(string text)
        {
            DefaultColor = ForeColor;

            GotFocus += (object sender, EventArgs e) =>
            {
                Text = string.Empty;
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

            if (!string.IsNullOrEmpty(text))
            {
                ForeColor = System.Drawing.Color.Gray;

                PlaceHolderText = text;
                Text = text;
            }
        }
    }
}

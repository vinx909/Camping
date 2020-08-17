using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Camping
{
    class TextBoxWithLabelFormElement
    {
        private const int textBoxOfsetDefault = 100;

        private int textBoxOfset;

        private Label label;
        private TextBox textBox;

        private Form form;

        public TextBoxWithLabelFormElement (Form form, string labelText)
        {
            this.form = form;
            textBoxOfset = textBoxOfsetDefault;

            label = new Label();
            label.Text = labelText;
            form.Controls.Add(label);

            textBox = new TextBox();
            form.Controls.Add(textBox);
        }
        public string GetValue()
        {
            return textBox.Text;
        }
        public void ChangePosition(int widthOfset, int heightOfset)
        {
            label.Location = new System.Drawing.Point(widthOfset, heightOfset);
            textBox.Location = new System.Drawing.Point(widthOfset + textBoxOfset, heightOfset);
        }
        public void SetTextBoxOfset(int ofset)
        {
            textBoxOfset = ofset;
        }
    }
}

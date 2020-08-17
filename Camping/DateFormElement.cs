using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OuderbijdrageSchool
{
    class DateFormElement
    {
        private const int textBoxOfsetDefault = 100;
        private const int textBoxBetweenOfsetDefault = 30;
        private const int textBoxWidthDefault = 25;

        private int textBoxOfset;
        private int textBoxBetweenOfset;
        private int textBoxWidth;

        private const int dateArrayLength = 3;
        private const int dateDayIndex = 0;
        private const int dateMonthIndex = 1;
        private const int dateYearIndex = 2;

        private Label label;
        private TextBox textBoxDay;
        private TextBox textBoxMonth;
        private TextBox textBoxYear;

        private Form form;

        public DateFormElement(Form form, string labelText)
        {
            this.form = form;
            textBoxOfset = textBoxOfsetDefault;
            textBoxBetweenOfset = textBoxBetweenOfsetDefault;
            textBoxWidth = textBoxWidthDefault;

            label = new Label();
            label.Text = labelText;
            form.Controls.Add(label);

            textBoxDay = new TextBox();
            textBoxDay.Width = textBoxWidth;
            form.Controls.Add(textBoxDay);

            textBoxMonth = new TextBox();
            textBoxMonth.Width = textBoxWidth;
            form.Controls.Add(textBoxMonth);

            textBoxYear = new TextBox();
            textBoxYear.Width = textBoxWidth;
            form.Controls.Add(textBoxYear);
        }

        public void ChangePosition(int widthOfset, int heightOfset)
        {
            CorrectPosition(widthOfset, heightOfset);
        }
        private void CorrectPosition(int widthOfset, int heightOfset)
        {
            label.Location = new Point(widthOfset, heightOfset);
            textBoxDay.Location = new Point(widthOfset + textBoxOfset, heightOfset);
            textBoxMonth.Location = new Point(widthOfset + textBoxOfset + textBoxBetweenOfset, heightOfset);
            textBoxYear.Location = new Point(widthOfset + textBoxOfset + textBoxBetweenOfset * 2, heightOfset);
        }
        public int[] GetDate()
        {
            int[] date = new int[dateArrayLength];
            date[dateDayIndex] = int.Parse(textBoxDay.Text);
            date[dateMonthIndex] = int.Parse(textBoxMonth.Text);
            date[dateYearIndex] = int.Parse(textBoxYear.Text);
            return date;
        }
        public static int GetYearIndex()
        {
            return dateYearIndex;
        }
        public static int GetMonthIndex()
        {
            return dateMonthIndex;
        }
        public static int GetDayIndex()
        {
            return dateDayIndex;
        }
        public void SetTextBoxOfset(int ofset)
        {
            textBoxOfset = ofset;
        }
        public void SetTextBoxBetweenOfset(int ofset)
        {
            textBoxBetweenOfset = ofset;
        }
        public void SetTextBoxWidthDefault(int width)
        {
            textBoxWidth = width;
            textBoxDay.Width = textBoxWidth;
            textBoxMonth.Width = textBoxWidth;
            textBoxYear.Width = textBoxWidth;
        }
    }
}

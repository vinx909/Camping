using OuderbijdrageSchool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Camping
{
    public partial class Form1 : Form
    {
        private const int widthMargin = 10;
        private const int heightMargin = 10;
        private const int rowHeight = 30;

        private const string arrivalDateString = "date of arival";
        private const string leaveDateString = "date of leave";
        private const string numberOfPeopleText = "amount of people";
        private const string numberOfDogsText = "amount of dogs";
        private const string addedOrRemovedMetersText = "amount of extra meters in width";
        private const string carAtTentText = "have car parked next to the tent";
        private const string calculatePriceButtonText = "calculate the price";

        private DateFormElement arrivalDate;
        private DateFormElement leaveDate;
        private TextBoxWithLabelFormElement numberOfPeople;
        private TextBoxWithLabelFormElement numberOfDogs;
        private TextBoxWithLabelFormElement addedOrRemovedMeters;
        private CheckBox carAtTent;
        private Button calculatePriceButton;

        public Form1()
        {
            InitializeComponent();
            InitializeElements();
            ResetPosition();
        }
        private void InitializeElements()
        {
            arrivalDate = new DateFormElement(this, arrivalDateString);
            leaveDate = new DateFormElement(this, leaveDateString);
            numberOfPeople = new TextBoxWithLabelFormElement(this, numberOfPeopleText);
            numberOfDogs = new TextBoxWithLabelFormElement(this, numberOfDogsText);
            addedOrRemovedMeters = new TextBoxWithLabelFormElement(this, addedOrRemovedMetersText);
            carAtTent = new CheckBox();
            carAtTent.Text = carAtTentText;
            Controls.Add(carAtTent);
            calculatePriceButton = new Button();
            calculatePriceButton.Text = calculatePriceButtonText;
            calculatePriceButton.Click += new EventHandler(CalculatePriceButtonFunction);
            Controls.Add(calculatePriceButton);
        }
        private void ResetPosition()
        {
            int row = 0;
            arrivalDate.ChangePosition(widthMargin, heightMargin + rowHeight * row);
            row++;
            leaveDate.ChangePosition(widthMargin, heightMargin + rowHeight * row);
            row++;
            numberOfPeople.ChangePosition(widthMargin, heightMargin + rowHeight * row);
            row++;
            numberOfDogs.ChangePosition(widthMargin, heightMargin + rowHeight * row);
            row++;
            addedOrRemovedMeters.ChangePosition(widthMargin, heightMargin + rowHeight * row);
            row++;
            carAtTent.Location = new Point(widthMargin, heightMargin + rowHeight * row);
            row++;
            calculatePriceButton.Location = new Point(widthMargin, heightMargin + rowHeight * row);
        }

        private void CalculatePriceButtonFunction(object sender, EventArgs e)
        {
            int[] arrivalDate = this.arrivalDate.GetDate();
            int[] leaveDate = this.leaveDate.GetDate();

            int arivalDay = arrivalDate[DateFormElement.GetDayIndex()];
            int arivalMonth = arrivalDate[DateFormElement.GetMonthIndex()];
            int arivalYear = arrivalDate[DateFormElement.GetYearIndex()];
            int leaveDay = leaveDate[DateFormElement.GetDayIndex()];
            int leaveMonth = leaveDate[DateFormElement.GetMonthIndex()];
            int leaveYear = leaveDate[DateFormElement.GetYearIndex()];
            int numberOfPeople;
            try
            {
                numberOfPeople = int.Parse(this.numberOfPeople.GetValue());
            }
            catch (FormatException exception)
            {
                numberOfPeople = 0;
            }
            int numberOfDogs;
            try
            {
                numberOfDogs = int.Parse(this.numberOfDogs.GetValue());
            }
            catch(FormatException exception)
            {
                numberOfDogs = 0;
            }
            int metersAddedRemoved;
            try
            {
                metersAddedRemoved = int.Parse(addedOrRemovedMeters.GetValue());
            }
            catch (FormatException exception)
            {
                metersAddedRemoved = 0;
            }
            bool withCar = carAtTent.Checked;

            MessageBox.Show(CalculateCampingPrice.Calculate(arivalDay, arivalMonth, arivalYear, leaveDay, leaveMonth, leaveYear, numberOfPeople, numberOfDogs, metersAddedRemoved, withCar));
        }
    }
}

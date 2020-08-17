using System;

namespace Camping
{
    internal class CalculateCampingPrice
    {
        private static readonly int[,] daysPerMonth = { { 1, 31 }, { 2, 28 }, { 3, 31 }, { 4, 30 }, { 5, 31 }, { 6, 30 }, { 7, 31 }, { 8, 31 }, { 9, 30 }, { 10, 31 }, { 11, 30 }, { 12, 31 } };
        private const int daysPerMonthMonthIndex = 0;
        private const int daysPerMonthAmountOfDaysIndex = 1;

        private static int highestMonth;

        private const int highSeasonStartMonth = 7;
        private const int highSeasonStartDay = 15;
        private const int highSeasonEndMonth = 8;
        private const int highSeasonEndDay = 19;

        private const int pricePerDayeHighSeason = 30;
        private const int pricePerDayLowSeason = 25;
        private const int pricePerDayPerPerson = 5;
        private const int pricePerDayPerDog = 4;
        private const int pricePerDayPerExtraMeter = 3;
        private const int priceReductionPerDayPerMeterLess = 2;
        private const int pricePeyDayWithCar = 6;

        private const string returnString = "the total price is ";
        private const string monthNotFoundExceptionString = "the month is not found in days per months and thus the program can't continue";

        private static void SetuptHighestMonth()
        {
            for(int i=0;i< daysPerMonth.GetLength(0);i++)
            {
                if(highestMonth<daysPerMonth[i, daysPerMonthMonthIndex])
                {
                    highestMonth = daysPerMonth[i, daysPerMonthMonthIndex];
                }
            }
        }
        internal static string Calculate(int arivalDay, int arivalMonth, int arivalYear, int leaveDay, int leaveMonth, int leaveYear, int numberOfPeople, int numberOfDogs, int metersAddedRemoved, bool withCar)
        {
            SetuptHighestMonth();

            int daysInHighSeason = 0;
            int daysInLowSeason = 0;

            int currentTestDay = arivalDay;
            int currentTestMonth = arivalMonth;
            int currentTestYear = arivalYear;
            while (currentTestYear < leaveYear || (currentTestYear == leaveYear && currentTestMonth < leaveMonth) || (currentTestYear == leaveYear && currentTestMonth == leaveMonth && currentTestDay <= leaveDay))
            {
                if ((currentTestMonth > highSeasonStartMonth && currentTestMonth < highSeasonEndMonth) ||
                    (currentTestMonth == highSeasonStartMonth && currentTestDay >= highSeasonStartDay) ||
                    (currentTestMonth == highSeasonEndMonth && currentTestDay <= highSeasonEndDay))
                {
                    daysInHighSeason++;
                }
                else
                {
                    daysInLowSeason++;
                }

                bool found = false;
                for (int i = 0; i < daysPerMonth.GetLength(0); i++)
                {
                    if (currentTestMonth == daysPerMonth[i, daysPerMonthMonthIndex])
                    {
                        found = true;
                        if (currentTestDay < daysPerMonth[i, daysPerMonthAmountOfDaysIndex])
                        {
                            currentTestDay++;
                        }
                        else
                        {
                            currentTestDay = 1;
                            if (currentTestMonth < highestMonth)
                            {
                                currentTestMonth++;
                            }
                            else
                            {
                                currentTestMonth = 1;
                                currentTestYear++;
                            }
                        }
                        break;
                    }
                }
                if (found == false)
                {
                    throw new Exception(monthNotFoundExceptionString);
                }
            }

            int totalDays = daysInHighSeason + daysInLowSeason;
            int total = 0;
            total += daysInHighSeason * pricePerDayeHighSeason;
            total += daysInLowSeason * pricePerDayLowSeason;
            total += pricePerDayPerPerson * numberOfPeople * totalDays;
            total += pricePerDayPerDog * numberOfDogs * totalDays;
            if (metersAddedRemoved > 0)
            {
                total += metersAddedRemoved * pricePerDayPerExtraMeter * totalDays;
            }
            else
            {
                total += metersAddedRemoved * priceReductionPerDayPerMeterLess * totalDays;
            }
            if (withCar)
            {
                total += pricePeyDayWithCar * totalDays;
            }

            return returnString + total;
        }
    }
}
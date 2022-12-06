using System;
using System.Collections.Generic;
using System.Linq;
using UITestTask.UI;

namespace UITestTask.Runtime
{
    public class CoinsCounter : TextSetter
    {
        private static List<int> WinterNumbers = new List<int>(3) { 12, 1, 2 };
        private static List<int> SpringNumbers = new List<int>(3) { 3, 4, 5 };
        private static List<int> SummerNumbers = new List<int>(3) { 6, 7, 8 };
        private static List<int> AutumnNumbers = new List<int>(3) { 9, 10, 11 };

        private List<List<int>> Seasons = new List<List<int>>(4)
            { WinterNumbers, SpringNumbers, SummerNumbers, AutumnNumbers };

        private void Awake() =>
            SetTextValue(Execute().ToString());

        private long Execute()
        {
            var month = 5;
            var year = DateTime.Today.Year;
            var day = 25;

            var previouslyMonths = new List<int>();

            foreach (var season in Seasons)
            {
                if (!season.Contains(month)) 
                    continue;
                
                var numberMonthInSeason = season.IndexOf(month);
                previouslyMonths = season.GetRange(0, numberMonthInSeason);
                break;
            }

            var daysCount = previouslyMonths.Sum(cachedMonth => DateTime.DaysInMonth(year, month)) + day;

            switch (daysCount)
            {
                case 1:
                    return 2;
                case 2:
                    return 3;
            }

            long oldYesterday = 2;
            long yesterday = 3;

            long today = 0;

            for (var i = 2; i < daysCount; i++)
            {
                today = (int)(yesterday + 0.6 * oldYesterday);
                oldYesterday = yesterday;
                yesterday = today;
            }

            return today;
        }
    }
}
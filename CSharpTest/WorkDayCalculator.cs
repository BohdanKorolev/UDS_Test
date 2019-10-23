using System;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            DateTime endDate = startDate;
            int weekendsDuration = 1;

            if (weekEnds == null)
            {
                endDate = startDate.AddDays(dayCount - 1);
            }
            else
            {
                for (int i = 1, j = 0; i < dayCount; i++)
                {
                    if ((j < weekEnds.Length) && (endDate == weekEnds[j].StartDate))
                    {
                        weekendsDuration += weekEnds[j].EndDate.Day - weekEnds[j].StartDate.Day;
                        endDate = endDate.AddDays(weekendsDuration);
                        j++;
                    }
                    endDate = endDate.AddDays(1);
                }
            }
            return endDate;
        }
    }
}

using System;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            DateTime endDate = startDate;
            int weekendsDuration;

            if (weekEnds == null)
            {
                endDate = startDate.AddDays(dayCount - 1);
            }
            else
            {
                for (int i = 1, j = 0; i < dayCount;)
                {
                    if ((j < weekEnds.Length) && (startDate >= weekEnds[j].StartDate) && (startDate <= weekEnds[j].EndDate))
                    {
                        endDate = endDate.AddDays((weekEnds[j].EndDate.Day - startDate.Day)+1);
                        j++;
                    }else if ((j < weekEnds.Length) && (endDate == weekEnds[j].StartDate))
                    {
                        weekendsDuration = 1;
                        weekendsDuration += weekEnds[j].EndDate.Day - weekEnds[j].StartDate.Day;
                        endDate = endDate.AddDays(weekendsDuration);
                        j++;
                    }
                    else
                    {
                        endDate = endDate.AddDays(1);
                        i++;
                    }
                }
            }
            return endDate;
        }
    }
}

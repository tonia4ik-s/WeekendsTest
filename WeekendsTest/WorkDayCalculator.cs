namespace WeekendsTest;

public class WorkDayCalculator : IWorkDayCalculator
{
    public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[]? weekEnds)
    {
        var endDate = startDate.AddDays(dayCount-1);
        if (weekEnds == null || weekEnds.Length == 0)
        {
            return endDate;
        }

        var duration = 0;
        var lastIterDate = startDate;
        foreach (var weekEnd in weekEnds)
        {
            var days = (weekEnd.StartDate - lastIterDate).Days;
            if (duration + days < dayCount)
            {
                duration += days;
                lastIterDate = weekEnd.EndDate.AddDays(1);
            }
            else if (duration + days == dayCount)
            {
                return weekEnd.StartDate.AddDays(-1);
            }
            else
            {
                var span = duration + days - dayCount + 1;
                return weekEnd.StartDate.AddDays(-span);
            }
        }

        var spanBack = dayCount - duration;
        endDate = lastIterDate.AddDays(spanBack-1);

        return endDate;
    }
}

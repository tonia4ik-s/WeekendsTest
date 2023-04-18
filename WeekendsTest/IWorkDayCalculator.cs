namespace WeekendsTest;

public interface IWorkDayCalculator
{
    DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[]? weekEnds);
}

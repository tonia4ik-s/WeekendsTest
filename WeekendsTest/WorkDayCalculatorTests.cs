using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WeekendsTest;

[TestClass]
public class WorkDayCalculatorTests
{
    [TestMethod]
    public void TestNoWeekEnd()
    {
        var startDate = new DateTime(2021, 12, 1);
        var count = 10;

        var result = new WorkDayCalculator().Calculate(startDate, count, null);

        Assert.AreEqual(startDate.AddDays(count - 1), result);
    }

    [TestMethod]
    public void TestNormalPath()
    {
        var startDate = new DateTime(2021, 4, 21);
        var count = 5;
        var weekends = new WeekEnd[]
        {
            new(new DateTime(2021, 4, 23), new DateTime(2021, 4, 25))
        };

        var result = new WorkDayCalculator().Calculate(startDate, count, weekends);

        Assert.IsTrue(result.Equals(new DateTime(2021, 4, 28)));
    }

    [TestMethod]
    public void TestWeekendAfterEnd()
    {
        var startDate = new DateTime(2021, 4, 21);
        var count = 4;
        var weekends = new WeekEnd[]
        {
            new(new DateTime(2021, 4, 23), new DateTime(2021, 4, 25)),
            new(new DateTime(2021, 5, 1), new DateTime(2021, 5, 3))
        };

        var result = new WorkDayCalculator().Calculate(startDate, count, weekends);
        Console.WriteLine(result);

        Assert.IsTrue(result.Equals(new DateTime(2021, 4, 27)));
    }
    
    [TestMethod]
    public void TestOneDay()
    {
        var startDate = new DateTime(2021, 12, 1);
        var count = 1;

        var result = new WorkDayCalculator().Calculate(startDate, count, null);

        Assert.AreEqual(new DateTime(2021, 12, 1), result);
    }
    
    [TestMethod]
    public void TestStartFromWeekEnds()
    {
        var startDate = new DateTime(2021, 12, 1);
        var count = 1;
        var weekends = new WeekEnd[]
        {
            new(new DateTime(2021, 12, 1), new DateTime(2021, 12, 2))
        };

        var result = new WorkDayCalculator().Calculate(startDate, count, weekends);

        Assert.IsTrue(result.Equals(new DateTime(2021, 12, 3)));
    }
}

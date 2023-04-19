using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WeekendsTest;

[TestClass]
public class WorkDayCalculatorTests
{
    private readonly IWorkDayCalculator _calculator = new WorkDayCalculator();
    
    [TestMethod]
    public void TestNoWeekEnd()
    {
        var startDate = new DateTime(2021, 12, 1);
        var count = 10;

        var result = _calculator.Calculate(startDate, count, null);

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

        var result = _calculator.Calculate(startDate, count, weekends);

        Assert.IsTrue(result.Equals(new DateTime(2021, 4, 28)));
    }

    [TestMethod]
    public void TestWeekendAfterEnd()
    {
        var startDate = new DateTime(2021, 4, 21);
        var count = 5;
        var weekends = new WeekEnd[]
        {
            new (new DateTime(2021, 4, 23), new DateTime(2021, 4, 25)),
            new (new DateTime(2021, 4, 29), new DateTime(2021, 4, 29))
        };
            
        var result = _calculator.Calculate(startDate, count, weekends);

        Assert.IsTrue(result.Equals(new DateTime(2021, 4, 28)));
    }
    
    [TestMethod]
    public void TestOneDay()
    {
        var startDate = new DateTime(2021, 12, 1);
        var count = 1;

        var result = _calculator.Calculate(startDate, count, null);

        Assert.AreEqual(new DateTime(2021, 12, 1), result);
    }
    
    [TestMethod]
    public void TestStartFromWeekEnds()
    {
        var startDate = new DateTime(2021, 12, 1);
        var count = 5;
        var weekends = new WeekEnd[]
        {
            new(new DateTime(2021, 12, 1), new DateTime(2021, 12, 2))
        };

        var result = _calculator.Calculate(startDate, count, weekends);

        Assert.IsTrue(result.Equals(new DateTime(2021, 12, 7)));
    }
    
    [TestMethod]
    public void TestWeekendAfterWeekend()
    {
        var startDate = new DateTime(2021, 12, 1);
        var count = 5;
        var weekends = new WeekEnd[]
        {
            new(new DateTime(2021, 12, 2),new DateTime(2021, 12, 3)),
            new(new DateTime(2021, 12, 4),new DateTime(2021, 12, 5))
        };

        var result = _calculator.Calculate(startDate, count, weekends);

        Assert.IsTrue(result.Equals(new DateTime(2021, 12, 9)));
    }
    
    [TestMethod]
    public void TestWeekendBeforeStart()
    {
        var startDate = new DateTime(2021, 12, 1);
        var count = 5;
        var weekends = new WeekEnd[]
        {
            new(new DateTime(2021, 11, 25),new DateTime(2021, 11, 28))
        };

        var result = _calculator.Calculate(startDate, count, weekends);

        Assert.IsTrue(result.Equals(new DateTime(2021, 12, 6)));
    }
    
    [TestMethod]
    public void TestStartInsideWeekEnds()
    {
        var startDate = new DateTime(2021, 12, 1);
        var count = 5;
        var weekends = new WeekEnd[]
        {
            new(new DateTime(2021, 11, 29),new DateTime(2021, 12, 2))
        };

        var result = _calculator.Calculate(startDate, count, weekends);

        Assert.IsTrue(result.Equals(new DateTime(2021, 12, 7)));
    }
    
    [TestMethod]
    public void TestWeekendEndsAtStarDate()
    {
        var startDate = new DateTime(2021, 12, 1);
        var count = 5;
        var weekends = new WeekEnd[]
        {
            new(new DateTime(2021, 11, 30),new DateTime(2021, 12, 1)),
            new(new DateTime(2021, 12, 6),new DateTime(2021, 12, 7))
        };

        var result = _calculator.Calculate(startDate, count, weekends);

        Assert.IsTrue(result.Equals(new DateTime(2021, 12, 8)));
    }
}

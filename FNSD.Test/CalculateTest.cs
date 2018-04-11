using System;
using FNSD.BL;
using FNSD.BL.Dtos;
using FNSD.BL.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FNSD.Test
{
  [TestClass]
  public class CalculateTest
  {
    [TestMethod]
    public void SpecificDayofMonth()
    {
      //-- Arrange
      Calculate calculate = new Calculate();
      var input = new SalaryDateCalculationDto
      {
        Day = 12,
        Week = 0,
        Current = new DateTime(2017, 7, 8),
        PaymentFrequency = SalaryFrequency.SpecificDayofMonth
      };

      var expected = "7/12/2017";
      // -- act
      var actual = calculate.CalculateNextSalaryDate(input).ToShortDateString();

      //-- Assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void SpecificDayofMonthDayBeforeCurrentDay()
    {
      //-- Arrange
      Calculate calculate = new Calculate();
      var input = new SalaryDateCalculationDto
      {
        Day = 14,
        Week = 0,
        Current = new DateTime(2017, 7, 20),
        PaymentFrequency = SalaryFrequency.SpecificDayofMonth
      };

      var expected = "8/14/2017";
      // -- act
      var actual = calculate.CalculateNextSalaryDate(input).ToShortDateString();

      //-- Assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void LastWorkingDayofMonth()
    {
      //-- Arrange
      Calculate calculate = new Calculate();
      var input = new SalaryDateCalculationDto
      {
        Day = 0,
        Week = 0,
        Current = new DateTime(2017, 6, 8),
        PaymentFrequency = SalaryFrequency.LastWorkingDayofMonth
      };

      var expected = "6/30/2017";
      // -- act
      var actual = calculate.CalculateNextSalaryDate(input).ToShortDateString();

      //-- Assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void LastWorkingDayofMonthForSeptember()
    {
      //-- Arrange
      Calculate calculate = new Calculate();
      var input = new SalaryDateCalculationDto
      {
        Day = 0,
        Week = 0,
        Current = new DateTime(2017, 9, 20),
        PaymentFrequency = SalaryFrequency.LastWorkingDayofMonth
      };

      var expected = "9/29/2017";
      // -- act
      var actual = calculate.CalculateNextSalaryDate(input).ToShortDateString();

      //-- Assert
      Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void DayBeforeLastWorkingDay()
    {
      //-- Arrange
      Calculate calculate = new Calculate();
      var input = new SalaryDateCalculationDto
      {
        Day = 0,
        Week = 0,
        Current = new DateTime(2017, 6, 8),
        PaymentFrequency = SalaryFrequency.DayBeforeLastWorkingDay
      };

      var expected = "6/29/2017";
      // -- act
      var actual = calculate.CalculateNextSalaryDate(input).ToShortDateString();

      //-- Assert
      Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void DayBeforeLastWorkingDayForSeptember()
    {
      //-- Arrange
      Calculate calculate = new Calculate();
      var input = new SalaryDateCalculationDto
      {
        Day = 0,
        Week = 0,
        Current = new DateTime(2017, 9, 20),
        PaymentFrequency = SalaryFrequency.DayBeforeLastWorkingDay
      };

      var expected = "9/28/2017";
      // -- act
      var actual = calculate.CalculateNextSalaryDate(input).ToShortDateString();

      //-- Assert
      Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void FirstWorkingdayofMonth()
    {
      //-- Arrange
      Calculate calculate = new Calculate();
      var input = new SalaryDateCalculationDto
      {
        Day = 0,
        Week = 0,
        Current = new DateTime(2017, 6, 8),
        PaymentFrequency = SalaryFrequency.FirstWorkingdayofMonth
      };

      var expected = "7/3/2017";
      // -- act
      var actual = calculate.CalculateNextSalaryDate(input).ToShortDateString();

      //-- Assert
      Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void FirstWorkingdayofMonthForFirstDayIsWeekend()
    {
      //-- Arrange
      Calculate calculate = new Calculate();
      var input = new SalaryDateCalculationDto
      {
        Day = 0,
        Week = 0,
        Current = new DateTime(2017, 10, 1),
        PaymentFrequency = SalaryFrequency.FirstWorkingdayofMonth
      };

      var expected = "10/2/2017";
      // -- act
      var actual = calculate.CalculateNextSalaryDate(input).ToShortDateString();

      //-- Assert
      Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void FirstWorkingdayofMonthForSeptember()
    {
      //-- Arrange
      Calculate calculate = new Calculate();
      var input = new SalaryDateCalculationDto
      {
        Day = 0,
        Week = 0,
        Current = new DateTime(2017, 8, 1),
        PaymentFrequency = SalaryFrequency.FirstWorkingdayofMonth
      };

      var expected = "9/1/2017";
      // -- act
      var actual = calculate.CalculateNextSalaryDate(input).ToShortDateString();

      //-- Assert
      Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void FirstXDay()
    {
      //-- Arrange
      Calculate calculate = new Calculate();
      var input = new SalaryDateCalculationDto
      {
        Day = 2,
        Week = 0,
        Current = new DateTime(2017, 7, 3),
        PaymentFrequency = SalaryFrequency.FirstXDay
      };

      var expected = "7/4/2017";
      // -- act
      var actual = calculate.CalculateNextSalaryDate(input).ToShortDateString();

      //-- Assert
      Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void FirstXDayExpectNextMonth()
    {
      //-- Arrange
      Calculate calculate = new Calculate();
      var input = new SalaryDateCalculationDto
      {
        Day = 2,
        Week = 0,
        Current = new DateTime(2017, 7, 6),
        PaymentFrequency = SalaryFrequency.FirstXDay
      };

      var expected = "8/1/2017";
      // -- act
      var actual = calculate.CalculateNextSalaryDate(input).ToShortDateString();

      //-- Assert
      Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void FirstXDayExpectThisMonth()
    {
      //-- Arrange
      Calculate calculate = new Calculate();
      var input = new SalaryDateCalculationDto
      {
        Day = 4,
        Week = 0,
        Current = new DateTime(2017, 7, 1),
        PaymentFrequency = SalaryFrequency.FirstXDay
      };

      var expected = "7/6/2017";
      // -- act
      var actual = calculate.CalculateNextSalaryDate(input).ToShortDateString();

      //-- Assert
      Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void LastXDay()
    {
      //-- Arrange
      Calculate calculate = new Calculate();
      var input = new SalaryDateCalculationDto
      {
        Day = 3,
        Week = 0,
        Current = new DateTime(2017, 7, 14),
        PaymentFrequency = SalaryFrequency.LastXDay
      };

      var expected = "7/26/2017";
      // -- act
      var actual = calculate.CalculateNextSalaryDate(input).ToShortDateString();

      //-- Assert
      Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void LastXDayForAugust()
    {
      //-- Arrange
      Calculate calculate = new Calculate();
      var input = new SalaryDateCalculationDto
      {
        Day = 1,
        Week = 0,
        Current = new DateTime(2017, 8, 18),
        PaymentFrequency = SalaryFrequency.LastXDay
      };

      var expected = "8/28/2017";
      // -- act
      var actual = calculate.CalculateNextSalaryDate(input).ToShortDateString();

      //-- Assert
      Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void LastXDayForSeptember()
    {
      //-- Arrange
      Calculate calculate = new Calculate();
      var input = new SalaryDateCalculationDto
      {
        Day = 5,
        Week = 0,
        Current = new DateTime(2017, 9, 21),
        PaymentFrequency = SalaryFrequency.LastXDay
      };

      var expected = "9/29/2017";
      // -- act
      var actual = calculate.CalculateNextSalaryDate(input).ToShortDateString();

      //-- Assert
      Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void NthXDayExpectNextMonth()
    {
      //-- Arrange
      Calculate calculate = new Calculate();
      var input = new SalaryDateCalculationDto
      {
        Day = 1,
        Week = 1,
        Current = new DateTime(2017, 6, 5),
        PaymentFrequency = SalaryFrequency.NthXDay
      };

      var expected = "7/3/2017";
      // -- act
      var actual = calculate.CalculateNextSalaryDate(input).ToShortDateString();

      //-- Assert
      Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void NthXDay()
    {
      //-- Arrange
      Calculate calculate = new Calculate();
      var input = new SalaryDateCalculationDto
      {
        Day = 3,
        Week = 3,
        Current = new DateTime(2017, 7, 8),
        PaymentFrequency = SalaryFrequency.NthXDay
      };

      var expected = "7/19/2017";
      // -- act
      var actual = calculate.CalculateNextSalaryDate(input).ToShortDateString();

      //-- Assert
      Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void NthXDayExpectLastDay()
    {
      //-- Arrange
      Calculate calculate = new Calculate();
      var input = new SalaryDateCalculationDto
      {
        Day = 5,
        Week = 5,
        Current = new DateTime(2017, 6, 14),
        PaymentFrequency = SalaryFrequency.NthXDay
      };

      var expected = "6/30/2017";
      // -- act
      var actual = calculate.CalculateNextSalaryDate(input).ToShortDateString();

      //-- Assert
      Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    [ExpectedException(typeof(Exception),
      "NoSuchDateException")]
    public void NthWeeksXDayExpectException()
    {
      //-- Arrange
      Calculate calculate = new Calculate();
      var input = new SalaryDateCalculationDto
      {
        Day = 1,
        Week = 1,
        Current = new DateTime(2017, 8, 10),
        PaymentFrequency = SalaryFrequency.NthWeeksXDay
      };

      // -- act
      calculate.CalculateNextSalaryDate(input);

      //-- Assert
    }
    [TestMethod]
    public void NthWeeksXDayTest()
    {
      //-- Arrange
      Calculate calculate = new Calculate();
      var input = new SalaryDateCalculationDto
      {
        Day = 3,
        Week = 3,
        Current = new DateTime(2017, 7, 8),
        PaymentFrequency = SalaryFrequency.NthWeeksXDay
      };

      var expected = "7/12/2017";
      // -- act
      var actual = calculate.CalculateNextSalaryDate(input).ToShortDateString();

      //-- Assert
      Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void NthWeeksXDay()
    {
      //-- Arrange
      Calculate calculate = new Calculate();
      var input = new SalaryDateCalculationDto
      {
        Day = 5,
        Week = 5,
        Current = new DateTime(2017, 6, 14),
        PaymentFrequency = SalaryFrequency.NthWeeksXDay
      };

      var expected = "6/30/2017";
      // -- act
      var actual = calculate.CalculateNextSalaryDate(input).ToShortDateString();

      //-- Assert
      Assert.AreEqual(expected, actual);
    }
  }
}

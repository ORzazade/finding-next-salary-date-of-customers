using System;
using FNSD.BL.Providers;

namespace FNSD.BL.Extensions
{
  public static class DateTimeExtensions
  {
    public static DateTime FirstDayOfMonth(this DateTime date)
    {
      return new DateTime(date.Year, date.Month, 1);
    }
    public static DateTime LastDayOfMonth(this DateTime date)
    {
      return date.FirstDayOfMonth().AddMonths(1).AddDays(-1);
    }
    public static DateTime WorkingDay(this DateTime date, bool first = true)
    {
      var result = new DateTime();
      var count = 1;
      for (var day = date; count <= 3; day = day.AddDays(first ? 1 : -1))
      {
        if (!OffDayProvider.IsOffDay(day))
        {
          result = day;
          break;
        }

        count++;
      }
      return result;
    }
    public static DateTime SpecificDayofMonth(this DateTime date, int day = 1)
    {
      var firstDay = date.FirstDayOfMonth().AddDays(day == 0 ? 0 : day - 1);
      if (firstDay < date)
      {
        firstDay = date.AddMonths(1).FirstDayOfMonth();
      }
      return firstDay;
    }
    public static DateTime FirstWorkingdayofMonth(this DateTime date)
    {
      var firstDay = date.FirstDayOfMonth();
      if (firstDay < date)
      {
        firstDay = date.AddMonths(1).FirstDayOfMonth();
      }
      return firstDay.WorkingDay();
    }
    public static DateTime LastWorkingdayofMonth(this DateTime date)
    {
      return date.LastDayOfMonth().WorkingDay(false);
    }
    public static DateTime DayBeforeLastWorkingDay(this DateTime date)
    {
      return date.LastDayOfMonth().WorkingDay(false).AddDays(-1);
    }
    public static DateTime FirstXDay(this DateTime date, int xday = 1)
    {
      var firstDay = date.FirstDayOfMonth();
      if (firstDay < date)
      {
        firstDay = date.AddMonths(1).FirstDayOfMonth();
      }
      DateTime result = new DateTime();
      int count = 0;
      for (DateTime day = firstDay; count < 7; day = day.AddDays(1))
      {
        if (OffDayProvider.IsXday(day, xday))
        {
          result = day;
          break;
        }
        count++;
      }
      return result;
    }
    public static DateTime LastXDay(this DateTime date, int xday = 1)
    {
      var lastDay = date.LastDayOfMonth();
      DateTime result = new DateTime();
      int count = 0;
      for (DateTime day = lastDay; count < 7; day = day.AddDays(-1))
      {
        if (OffDayProvider.IsXday(day, xday))
        {
          result = day;
          break;
        }
        count++;
      }
      return result;
    }
    public static DateTime NthXDay(this DateTime date, int xday = 1, int week = 1)
    {
      var firstDay = date.FirstDayOfMonth();
      DateTime result = new DateTime();
      int count = 0;
      for (DateTime day = firstDay.AddDays(7 * (week - 1)); count < 7; day = day.AddDays(1))
      {
        if (OffDayProvider.IsXday(day, xday))
        {
          result = day;
          break;
        }
        count++;
      }
      return result;
    }
  }

}

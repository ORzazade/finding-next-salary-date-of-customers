using FNSD.BL.Interfaces;
using System;

namespace FNSD.BL.Providers
{
  public class WeekendProvider : IOffDayProvider
  {
    public bool IsWeekend(DateTime date)
    {
      return date.DayOfWeek == DayOfWeek.Sunday
             || date.DayOfWeek == DayOfWeek.Saturday;
    }
    public bool IsXday(DateTime date, int xday = 1)
    {
      var at = (int)date.DayOfWeek;
      return date.DayOfWeek == (DayOfWeek)xday;
    }
    public bool IsOffDay(DateTime date)
    {
      return IsWeekend(date);
    }
    public bool IsWorkingDay(DateTime date)
    {
      return !IsWeekend(date);
    }

  }

}

using System;
using FNSD.BL.Dtos;
using FNSD.BL.Enums;
using FNSD.BL.Extensions;
using FNSD.BL.Interfaces;
using FNSD.BL.Providers;

namespace FNSD.BL
{
  public class Calculate : IPaymentDateCalculator
  {
    public DateTime CalculateNextSalaryDate(SalaryDateCalculationDto date)
    {
      OffDayProvider.Providers.Add(new WeekendProvider());
      switch (date.PaymentFrequency)
      {
        case SalaryFrequency.SpecificDayofMonth:
          //Console.WriteLine("{0} -- {1}", date.Current.ToShortDateString(), date.Current.SpecificDayofMonth(date.Day));
          return date.Current.SpecificDayofMonth(date.Day);
        case SalaryFrequency.FirstWorkingdayofMonth:
          return date.Current.FirstWorkingdayofMonth();
        case SalaryFrequency.LastWorkingDayofMonth:
          return date.Current.LastWorkingdayofMonth();
        case SalaryFrequency.DayBeforeLastWorkingDay:
          return date.Current.DayBeforeLastWorkingDay();
        case SalaryFrequency.FirstXDay:
          return date.Current.FirstXDay(date.Day);
        case SalaryFrequency.LastXDay:
          return date.Current.LastXDay(date.Day);
        case SalaryFrequency.NthXDay:
          return date.Current.NthXDay(date.Day, date.Week);
      }

      return DateTime.Now;
    }
  }
}

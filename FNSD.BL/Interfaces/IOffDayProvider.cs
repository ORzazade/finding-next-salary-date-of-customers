using System;

namespace FNSD.BL.Interfaces
{
  public interface IOffDayProvider
  {
    bool IsOffDay(DateTime date);
    bool IsEndOfWeek(DateTime date);
    bool IsXday(DateTime date, int xday);
  }
}

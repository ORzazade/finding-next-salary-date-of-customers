using System;
using System.Collections.Generic;
using System.Linq;
using FNSD.BL.Interfaces;

namespace FNSD.BL.Providers
{
  public static class OffDayProvider
  {
    public static readonly ICollection<IOffDayProvider> Providers = new List<IOffDayProvider>();

    public static bool IsOffDay(DateTime date)
    {
      return Providers.Any(x => x.IsOffDay(date));
    }
    public static bool IsXday(DateTime date, int xday)
    {
      return Providers.Any(x => x.IsXday(date, xday));
    }
  }

}

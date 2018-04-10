using System;
using FNSD.BL.Enums;

namespace FNSD.BL.Dtos
{
  public class SalaryDateCalculationDto
  {
    public int Day { get; set; }
    public int Week { get; set; }
    public DateTime Current { get; set; }
    public SalaryFrequency PaymentFrequency { get; set; }
  }
}

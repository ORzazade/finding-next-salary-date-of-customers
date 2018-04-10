using System;
using FNSD.BL.Dtos;

namespace FNSD.BL.Interfaces
{
  interface IPaymentDateCalculator
  {
    DateTime CalculateNextSalaryDate(SalaryDateCalculationDto date);
  }
}

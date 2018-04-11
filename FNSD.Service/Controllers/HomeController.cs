using System;
using System.Web.Mvc;
using FNSD.BL;
using FNSD.BL.Dtos;
using FNSD.BL.Enums;

namespace FNSD.Service.Controllers
{
  public class HomeController : Controller
  {
    public JsonResult Index()
    {
      ViewBag.Title = "Home Page";

      Calculate calculate = new Calculate();
      var input = new SalaryDateCalculationDto
      {
        Day = 3,
        Week = 3,
        Current = new DateTime(2017, 7, 8),
        PaymentFrequency = SalaryFrequency.NthWeeksXDay
      };
      var data = calculate.CalculateNextSalaryDate(input);
      return Json(data.ToShortDateString(), JsonRequestBehavior.AllowGet);
    }
  }
}

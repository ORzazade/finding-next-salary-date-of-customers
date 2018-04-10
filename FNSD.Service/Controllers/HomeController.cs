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
      var data=calculate.CalculateNextSalaryDate(new SalaryDateCalculationDto
      {
        Day = 12,
        Week = 0,
        Current = DateTime.Now,
        PaymentFrequency = SalaryFrequency.FirstWorkingdayofMonth
      });
      return Json(data.ToShortDateString(), JsonRequestBehavior.AllowGet);
    }
  }
}

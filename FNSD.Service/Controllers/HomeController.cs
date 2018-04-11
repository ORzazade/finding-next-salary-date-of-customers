using System;
using System.Web.Http;
using System.Web.Http.Description;
using FNSD.BL;
using FNSD.BL.Dtos;

namespace FNSD.Service.Controllers
{
  /// <summary>
  /// Manages Salary date info
  /// </summary>
  public class HomeController : ApiController
  {
    /// <summary>
    /// Finds next salary dates of customer
    /// </summary>
    /// <param name="input"></param>
    /// <returns>Next salary date</returns>
    [HttpPost]
    [ResponseType(typeof(DateTime))]
    public IHttpActionResult Index(SalaryDateCalculationDto input)
    {
      Calculate calculate = new Calculate();
      
      var data = calculate.CalculateNextSalaryDate(input);
      return Ok(data.Date);
    }
  }
}


using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Utilities;
using ReportService.Services;
namespace ReportService.Controllers
{
    
    // original

    [Route("api/values")]
    public class ReportController : Controller
    {
        private readonly IAccountingReportForMonthService _accountingReportForMonthService;

        public ReportController(IAccountingReportForMonthService accountingReportForMonthService)
        {
            _accountingReportForMonthService = accountingReportForMonthService;
        }

        [HttpGet]
        [Route("{year}/{month}")]
        public IActionResult Download(int year, int month)
        {
            
            string reportString = _accountingReportForMonthService.GetReportForMonth(year,month);
            var file = System.IO.File.ReadAllBytes("E:\\report.txt");
            var response = File(file, "application/octet-stream","report.txt");
            return response;
        }
    }
}

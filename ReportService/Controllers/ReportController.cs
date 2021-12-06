
using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
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
            return File(Encoding.UTF8.GetBytes(reportString), "application/octet-stream", "report.txt");
        }
    }
}

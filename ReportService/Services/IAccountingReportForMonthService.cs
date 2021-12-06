namespace ReportService.Services
{
    public interface IAccountingReportForMonthService
    {
        string GetReportForMonth(int year, int month);
    }
}
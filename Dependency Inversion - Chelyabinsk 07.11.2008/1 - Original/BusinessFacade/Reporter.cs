using System.Collections.Generic;

namespace BusinessFacade
{
    public class Reporter
    {
        public void SendReports()
        {
            var reportBuilder = new ReportBuilder();
            IList<Report> reports = reportBuilder.CreateReports();

            var reportSender = new EmailReportSender();
            foreach (Report report in reports)
            {
                reportSender.Send(report);
            }
        }
    }
}
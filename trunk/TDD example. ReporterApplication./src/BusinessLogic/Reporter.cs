using System.Collections.Generic;
using Domain;

namespace BusinessLogic
{
    public class Reporter
    {
        private readonly IReportBuilder reportBuilder;
        private readonly IReportSender reportSender;

        public Reporter(IReportBuilder reportBuilder, IReportSender reportSender)
        {
            this.reportBuilder = reportBuilder;
            this.reportSender = reportSender;
        }

        public int SendReports()
        {
            IList<Report> reports = reportBuilder.CreateRegularReports();

            if (reports.Count == 0)
            {
                reportSender.Send(reportBuilder.CreateSpecialReport());
            }

            foreach (Report report in reports)
            {
                reportSender.Send(report);
            }

            return reports.Count;
        }
    }
}
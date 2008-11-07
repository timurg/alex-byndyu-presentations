using System.Collections.Generic;
using Domain;

namespace BusinessFacade
{
    public class Reporter : IReporter
    {
        private readonly IReportBuilder reportBuilder;
        private readonly IReportSender reportSender;

        public Reporter(IReportBuilder reportBuilder, IReportSender reportSender)
        {
            this.reportBuilder = reportBuilder;
            this.reportSender = reportSender;
        }

        #region IReporter Members

        public void SendReports()
        {
            IList<Report> reports = reportBuilder.CreateReports();
            foreach (Report report in reports)
            {
                reportSender.Send(report);
            }
        }

        #endregion
    }
}
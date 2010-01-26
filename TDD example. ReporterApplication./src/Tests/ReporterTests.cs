using System.Collections.Generic;
using BusinessLogic;
using Domain;
using Moq;
using Xunit;

namespace Tests
{
    public class ReporterTests
    {
        [Fact]
        public void ReturnCountOfSentReports()
        {
            var reportBuilder = new Mock<IReportBuilder>();
            var reportSender = new Mock<IReportSender>();

            // задаем поведение для интерфейса IReportBuilder
            reportBuilder.Setup(m => m.CreateRegularReports())
                .Returns(new List<Report> {new Report(), new Report()});

            var reporter =  new Reporter(reportBuilder.Object, reportSender.Object);
            
            var reportCount = reporter.SendReports();

            Assert.Equal(2, reportCount);
        }

        [Fact]
        public void SendAllReports()
        {
            var reportBuilder = new Mock<IReportBuilder>();
            var reportSender = new Mock<IReportSender>();

            reportBuilder.Setup(m => m.CreateRegularReports())
                .Returns(new List<Report> {new Report(), new Report()});

            var reporter =  new Reporter(reportBuilder.Object, reportSender.Object);
            
            reporter.SendReports();

            reportSender.Verify(m => m.Send(It.IsAny<Report>()), Times.Exactly(2));
        }

        [Fact]
        public void SendSpecialReportToAdministratorIfNoReportsCreated()
        {
            var reportBuilder = new Mock<IReportBuilder>();
            var reportSender = new Mock<IReportSender>();

            reportBuilder.Setup(m => m.CreateRegularReports()).Returns(new List<Report>());
            reportBuilder.Setup(m => m.CreateSpecialReport()).Returns(new SpecialReport());

            var reporter =  new Reporter(reportBuilder.Object, reportSender.Object);
            
            reporter.SendReports();

            reportSender.Verify(m => m.Send(It.IsAny<SpecialReport>()), Times.Once());
        }
    }
}
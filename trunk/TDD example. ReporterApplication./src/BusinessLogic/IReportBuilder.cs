using System.Collections.Generic;
using Domain;

namespace BusinessLogic
{
    public interface IReportBuilder
    {
        IList<Report> CreateRegularReports();
        SpecialReport CreateSpecialReport();
    }
}
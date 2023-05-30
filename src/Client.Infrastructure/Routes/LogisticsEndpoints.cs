using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grs.BioRestock.Client.Infrastructure.Routes
{
    public class LogisticAreaEndpoints
    {
        public static string GetSites = "/api/LogisticArea/GetSites";
    }

    public class LogisticEmployeesEndpoints
    {
        public static string GetEmployees = "/api/Employee/GetAll";
    }
}
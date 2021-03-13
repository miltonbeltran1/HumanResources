using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAL.Routes.V1
{
    public static class ApiRoutes
    {
        public const string Root = "Catalog/api";
        public const string Version = "v1_0";
        public const string Base = Root + "/" + Version;
        
        public class Employee
        {
            public const string IdEmployee = "idEmployee";
            public const string GetAll = Base + "/Employee/GetAll";
            public const string Get = Base + "/Employee/Get";
            public const string EmployeeBaseRouteSection = "EmployeeService:BaseRoute";
        }
    }
}

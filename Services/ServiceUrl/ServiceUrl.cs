using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDemo.Services.Url
{
    public class ServiceUrl
    {
        //private static string BaseUrl => "https://localhost:7276";
        public static string GetStudentUrl =>  "/api/Student/GetListofStudent";
        public static string GetByIdUrl => "/api/Student/";
        public static string UpdateUrl =>   "/api/Student/Update";
        public static string DeleteUrl => "/api/Student/";
        public static string CreateUrl =>  "/api/Student/Create";

    }
}



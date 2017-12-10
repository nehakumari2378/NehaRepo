using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Mvc;

namespace EmployeeServices.Controllers
{
    public class EmployeeController : ApiController
    {
        [BasicAuthentication]
        public HttpResponseMessage Get(string gender="All")
        {
            var username = Thread.CurrentPrincipal.Identity.Name;

            using (EmployeeDBEntities2 entities = new EmployeeDBEntities2())
            {
                //return entities.Employees.ToList();
                switch (username.ToLower())
                {
                    case "male":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Employees.Where(e => e.Gender.ToLower() == "male").ToList());
                    case "female":
                        return Request.CreateResponse(HttpStatusCode.OK,entities.Employees.Where(e=>e.Gender=="female").ToList());
                            
                    default:
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid entry");
                }
            }
        }

        public Employee Get(int id)
        {
            using (EmployeeDBEntities2 entities = new EmployeeDBEntities2())
            {
                return entities.Employees.FirstOrDefault(e=>e.ID==id);
            }
        }

        //Implementing POST method
        public void Post([FromBody] Employee employee)
        {
            using (EmployeeDBEntities2 entities = new EmployeeDBEntities2())
            {
                entities.Employees.Add(employee);
                entities.SaveChanges();
            }
        }
    }
}

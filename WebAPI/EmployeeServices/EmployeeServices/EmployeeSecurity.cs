using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace EmployeeServices
{
    public class EmployeeSecurity
    {
        public static bool Login(string username, string password)
        {
            using (EmployeeDBEntities2 entities = new EmployeeDBEntities2())
            {
                return entities.Users.Any(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && u.Password == password);
            }
        }
    }
}
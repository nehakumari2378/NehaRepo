using System.Web;
using System.Web.Mvc;

namespace EmployeeService_TokenAuth_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

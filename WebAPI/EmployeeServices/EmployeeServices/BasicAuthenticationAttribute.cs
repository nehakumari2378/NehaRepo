using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace EmployeeServices
{
    public class BasicAuthenticationAttribute:AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string AuthenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string DecodedAuthenticationToken =Encoding.UTF8.GetString(Convert.FromBase64String(AuthenticationToken));
                string[] AuthenticationTokenArray = DecodedAuthenticationToken.Split(':');
                string UsernameArray = AuthenticationTokenArray[0];
                string PasswordArray = AuthenticationTokenArray[1];

                if (EmployeeSecurity.Login(UsernameArray, PasswordArray))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(UsernameArray), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);

                }
            }
        }
    }
}
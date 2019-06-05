using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Routing;

namespace Ex3.Controllers
{
    public class IPConstraint : IRouteConstraint
    {
        public bool Match(
                HttpContextBase httpContext, Route route, string parameterName,
                RouteValueDictionary values, RouteDirection routeDirection)
        {

            // Constraint ip, math the given value and return true if valid ip adress.
            object value;
            IPAddress check = null;
            return values.TryGetValue(parameterName, out value) && value != null ?
                IPAddress.TryParse(values[parameterName].ToString(), out check) : false;
        }
    }
}

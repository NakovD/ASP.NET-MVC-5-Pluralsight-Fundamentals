using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Mvc;

namespace OddToFood.Web.Api
{
    public class RestaurantsController : ApiController
    {
        [HttpGet]
        public object GetSomeProp()
        {
            var someStuff = new { someth = "hallo" };
            return someStuff;
        }

        [HttpGet]
        public object Something(string attribute)
        {
            if (!string.IsNullOrEmpty(attribute))
            {
                return new { prop = $"You receive your prop 3x times: {attribute}X3" };
            }
            else
            {
                return new { prop = "You receive nothing" };
            }
        }
    }
}

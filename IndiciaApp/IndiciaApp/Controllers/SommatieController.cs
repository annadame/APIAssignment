using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IndiciaApp.Controllers
{
    public class SommatieController : ApiController
    {
        private static object[] InputValues()
        {
            return new[]
            {
                "5",
                "1,2e2",
                null,
                "    -5555",
                "6.767"
            };
        }

        public int GetResult()
        {
            int result = 0;

            return result;
        }

    }
}

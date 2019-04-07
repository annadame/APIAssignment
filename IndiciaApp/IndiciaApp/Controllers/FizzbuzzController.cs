using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IndiciaApp.Controllers
{
    public class FizzbuzzController : ApiController
    {
        //[Route("Fizzbuzz/{from}/{to}")]
        public IEnumerable<string> Get([FromUri] int from, int to)
        {
            int number = to;
            List<string> output = new List<string>();

            for (int i = from; i <= number; i++)
            {
                List<string> fizzbuzzvalues = new List<string>();

                if (i % 3 == 0)
                {
                    fizzbuzzvalues.Add("Fizz");
                }

                if (i % 5 == 0)
                {
                    fizzbuzzvalues.Add("Buzz");
                }

                if (fizzbuzzvalues.Count <= 0)
                {
                    output.Add(i.ToString());
                }
                else
                {
                    string values = String.Join("", fizzbuzzvalues.ToArray());
                    output.Add(values);
                }
            }

            return output;
        }
    }
}

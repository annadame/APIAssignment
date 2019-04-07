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
        public IEnumerable<string> Get([FromUri] int from, int to)
        {
            int number = to;

            for (int i = from; i <= number; i++)
            {
                string output = "";
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
                    output = i.ToString();
                }
                else
                {
                    output = String.Join("", fizzbuzzvalues.ToArray());
                }

                yield return output;
            }
        }
    }
}

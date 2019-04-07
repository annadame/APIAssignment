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

                //check modulo 3, if yes add fizz to list
                if (i % 3 == 0)
                {
                    fizzbuzzvalues.Add("Fizz");
                }

                //check modulo 5, if yes add buzz to list
                if (i % 5 == 0)
                {
                    fizzbuzzvalues.Add("Buzz");
                }

                //if list is empty, no modulo "was found"
                if (fizzbuzzvalues.Count <= 0)
                {
                    output = i.ToString();
                }
                else //adds the found modulo to the output string
                {
                    output = String.Join("", fizzbuzzvalues.ToArray());
                }

                yield return output;
            }
        }

    }
}

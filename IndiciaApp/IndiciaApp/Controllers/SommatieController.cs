using System;
using System.Collections.Generic;
using System.Globalization;
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

        public string GetResult()
        {
            List<string> values = new List<string>();

            foreach (var objects in InputValues()) {
                if (objects != null)
                {
                    values.Add(objects.ToString());
                }
            }

            int result = 0;

            for (int i = 0; i < values.Count; i++)
            {
                if (values[i].Contains("e"))
                {
                    decimal exponentionalResult;
                    Decimal.TryParse(values[i], System.Globalization.NumberStyles.Float, null, out exponentionalResult);
                    values[i] = exponentionalResult.ToString();
                }

                if (values[i].Contains("."))
                {
                    values[i] = values[i].Replace(".", "");
                }

                result += int.Parse(values[i]);
            }

            var nfi = new NumberFormatInfo { NumberDecimalSeparator = ",", NumberGroupSeparator = "." };
            return result.ToString("#,##", nfi);
        }

    }
}

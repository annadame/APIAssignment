using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IndiciaApp.Controllers
{
    public class GroupController : ApiController
    {
        private Dictionary<int, int> list;

        private static IEnumerable<int> RandomNumbers(int seed = 123)
        {
            var random = new System.Random(seed);
            for (int i = 0; i < 1000; i++)
            {
                yield return random.Next(25);
            }
        }

        public Dictionary<int, int> GenerateList()
        {
            list = new Dictionary<int, int>();
            foreach (int currentNumber in RandomNumbers())
            {
                if (list.ContainsKey(currentNumber)) {
                    int value = list[currentNumber];
                    list[currentNumber] = value + 1;
                } else
                {
                    list.Add(currentNumber, 1);
                }
            }

            return list;
        }

        [Route("group/plain")]
        public List<KeyValuePair<int, int>> GetGroupOne()
        {
            return GenerateList().OrderByDescending(x => x.Key).ToList();
        }

        [Route("group/json")]
        public List<KeyValuePair<int, int>> GetGroupTwo()
        {
            return GenerateList().OrderBy(x => x.Value).ToList();
        }
    }
}

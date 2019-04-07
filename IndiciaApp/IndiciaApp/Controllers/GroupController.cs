using Newtonsoft.Json;
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

        //generate list with key and value
        public Dictionary<int, int> GenerateList()
        {
            list = new Dictionary<int, int>();
            foreach (int currentNumber in RandomNumbers())
            {
                //if key exists, add one to value
                if (list.ContainsKey(currentNumber)) {
                    int value = list[currentNumber];
                    list[currentNumber] = value + 1;
                }
                else //if key does not exist, make a new one and set the value to 1
                {
                    list.Add(currentNumber, 1);
                }
            }

            return list;
        }

        //assignment group 1
        [Route("group/plain")]
        public List<KeyValuePair<int, int>> GetGroupOne()
        {
            //returns the list in right order
            return GenerateList().OrderByDescending(x => x.Key).ToList();
        }

        //assignment group 2
        [Route("group/json")]
        public string GetGroupTwo()
        {
            //convert the list to json and set it in right order
            return JsonConvert.SerializeObject(GenerateList().OrderBy(x => x.Value).ToList());
        }
    }
}

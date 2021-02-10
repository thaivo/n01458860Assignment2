using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01458860Assignment2.Controllers
{
    public class J2Controller : ApiController
    {
        private const string message1 = "There are ";
        private const string message2 = " ways to get the sum 10.";
        /// <summary>
        /// Calculate the number of way for 2 dice to get the total of 10
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/J2/DiceGame/{m}/{n}")]
        public string DiceGame(int m, int n)
        {
            string result = "";
            int way = m + n - 9;
            int max = m;
            int min = n;
            if (m <= n)
            {
                max = n;
                min = m;
            }
            
            if (way < 1)
            {
                result = message1 + "0" + message2;
            }
            else if (way < min && way < max)
            {
                result = message1 + way.ToString() + message2;
            }
            else if(way > min )
            {
                result = message1 + min.ToString() + message2;
            }
            return result;
        }
    }
}

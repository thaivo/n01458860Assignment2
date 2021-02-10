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
        /// <param name="m">the number of sides on the first die</param>
        /// <param name="n">the number of sides on the second die</param>
        /// <returns>
        /// a message with the format "There are n ways to get the sum 10." 
        /// </returns>
        /// <example>
        /// GET ../api/J2/DiceGame/6/8 -> response: There are 5 total ways to get the sum 10.
        /// </example>
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

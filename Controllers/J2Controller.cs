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
        private const string MESSAGE1 = "There are ";
        private const string WAY_STR = " way";
        private const string MESSAGE2 = " to get the sum 10.";
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
            //Validate input 
            if (m < 1 || m > 1000 || n < 1 || n > 100) return "Invalid input";

            string result = "";
            string message2 = WAY_STR;
            int way = m + n - 9;
            
            //we only need to find the number of ways basing on minimum value of inputs.
            int min = m;
            if (m > n)
            {
                min = n;
            }
            
            if (way < 1)
            {
                way = 0;
            }
            else if (min >= 9)//min and max are equal to or greater than 9
            {
                way = 9;
            }
            else if(min > 0 && min < 10 && way > min)
            {
                way = min;
            }
            //if there are more than one way, we append s into message2;
            if (way > 1) message2 += "s";

            //combine result from messages;
            result = MESSAGE1 + way.ToString() + message2 + MESSAGE2;
            return result;
        }
    }
}

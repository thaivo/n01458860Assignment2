using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01458860Assignment2.Controllers
{
    public class J1Controller : ApiController
    {
        private int[] burgers = { 461, 431, 420, 0 };
        private int[] drinks = { 130, 160, 118, 0 };
        private int[] sides = { 100, 57, 70, 0 };
        private int[] desserts = { 167, 266, 75, 0 };

        /// <summary>
        /// Compute the total Calories of the meal
        /// and result string include the total
        /// </summary>
        /// <param name="burger">index of burger</param>
        /// <param name="drink">index of drink</param>
        /// <param name="side">index of side</param>
        /// <param name="dessert">index of dessert</param>
        /// <returns> Message show the total Calories of the meal</returns>
        /// <example>
        /// GET ../api/J1/Menu/1/2/3/4
        /// -> Response is "Your total calorie count is 691"
        /// </example>
        [HttpGet]
        [Route("api/j1/menu/{burger}/{drink}/{side}/{dessert}")]
        public string Menu(int burger, int drink, int side, int dessert)
        {
            string result = "Your total calorie count is ";
            int total = burgers[burger-1] + drinks[drink-1] + sides[side-1] + desserts[dessert-1];
            return result + total.ToString();
        }
    }
}

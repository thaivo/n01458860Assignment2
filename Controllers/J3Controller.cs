using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01458860Assignment2.Controllers
{
    public class J3Controller : ApiController
    {
        private const string invalidInputMessage = "Invalid input";
        /// <summary>
        /// https://cemc.math.uwaterloo.ca/contests/computing/2020/ccc/juniorEF.pdf
        /// Determining the coordinates of the smallest possible rectangular
        /// frame such that each drop of paint lies inside the frame.Points on the frame are not considered
        /// inside the frame
        /// </summary>
        /// <param name="input">
        /// An array of integers 
        /// first index is the number of drops of paint
        /// each next two indexes of array are coordinates of each point
        /// </param>
        /// <returns>array of strings: 
        ///     first index is  the coordinates of the bottom-left corner of the rectangular frame
        ///     second index is  the coordinates of the top-right corner of the rectangular frame.
        /// </returns>
        /// <example>
        /// GET api/j3/calculate/input?input=5&input=44&input=62&input=34&input=69&input=24&input=78&input=42&input=44&input=64&input=10
        /// ->Response is : 
        ///         <string>23, 9</string>
        ///         <string>65, 79</string>
        /// </example>
        [HttpGet]
        [Route("api/j3/calculate/{input?}")]
        public IEnumerable<string> Calculate([FromUri] int[] input)
        {
            //Validate input[0]
            //input[0] is [2,100]
            //input[0] is the number of pairs of coordinate.
            // So (1 + input[0]*2) is the size of input array.
            if (input == null
                || input[0] < 2 || input[0] > 100
                || input[0] != ((input.Length - 1) / 2)) return new string[] { invalidInputMessage };
            //Validate input array
            //Because input[0] satisfies the condition of the problem
            //so we only need to check element from the index 1 of the input.
            for (int index = 1; index < input.Length; index++)
            {
                //if coordinates are not positive or greater than 99, invalid message of input will be thrown.
                if (input[index] < 1 || input[index] > 99)
                {
                    return new string[] { invalidInputMessage };
                }
            }

            int maxX, minX, maxY, minY, indexX, indexY;
            //initialize max min coordinates
            maxX = minX = input[1];
            maxY = minY = input[2];
            //array start from index 0
            //Because 2 next indexes are assigned
            //so we will start from index 3
            int loopTimes = (input.Length - 3) / 2;
            for (int count = 0; count < loopTimes; count++)
            {
                //Odd indexes are X Coordinates
                indexX = 3 + count * 2;
                //Even indexes are Y Coordinates
                indexY = 4 + count * 2;
                if (maxX < input[indexX])
                {
                    maxX = input[indexX];
                }
                else if (minX > input[indexX])
                {
                    minX = input[indexX];
                }

                if (maxY < input[indexY])
                {
                    maxY = input[indexY];
                }
                else if (minY > input[indexY])
                {
                    minY = input[indexY];
                }
            }
            return new string[] { "" + (minX - 1) + ", " + (minY - 1), "" + (maxX + 1) + ", " + (maxY + 1) };

        }
    }
}

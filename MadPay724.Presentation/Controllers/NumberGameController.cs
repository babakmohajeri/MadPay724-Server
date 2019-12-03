using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MadPay724.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberGameController : ControllerBase
    {
        private static readonly string[] day = new string[] { "Monday", "Thuesday", "Wendsday", "Thersdauy", "Friday", "saturday", "Sunday" };
        List<Days> myday = new List<Days>();

        //Test New

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            for (int i = 0; i < day.Length; i++)
            {
                Days md = new Days()
                {
                    DayName = day[i].ToString(),
                    DayNumber = i + 1
                };
                myday.Add(md);
            }
            int c = myday.Count();
            string[] myText = new string[c];

            foreach (var item in myday)
            {
                myText[item.DayNumber - 1] = "My day is: " + item.DayName;
            }
            return myText;
        }

        [HttpGet("{num}")]
        public async Task<ActionResult<IEnumerable<Days>>> Get(int num)
        {
            if (num > 0 && num <= 7)
            {
                Days md = new Days()
                {
                    DayName = day[num - 1].ToString(),
                    DayNumber = num
                };
                myday.Add(md);
                return myday.ToArray();
            }
            else
            {
                List<Days> mdn = null;
                await Response.WriteAsync("Error. Please enter a number between 1-7");
                return mdn;
            }
        }
    }
}
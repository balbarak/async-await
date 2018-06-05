using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitSample.Models
{
    public class WebResult
    {
        public string Url { get; set; }
        
        public long? ContentSize { get; set; }

        public long TotalMilliseconds { get; set; }

        public static List<WebResult> CreateSample()
        {
            List<WebResult> result = new List<WebResult>
            {
                new WebResult()
                {
                    Url = "http://www.google.com",
                    ContentSize = 20394,
                    TotalMilliseconds = 3034,
                },

                new WebResult()
                {
                    Url = "http://www.yahoo.com",
                    ContentSize = 3234,
                    TotalMilliseconds = 434,
                }
            };

            return result;
        }
    }
}

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
    }
}

using AsyncAwaitSample.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitSample.Services
{
    public class DataService
    {
        public static DataService Instance { get; }

        static DataService()
        {
            Instance = new DataService();
        }

        public async Task<WebResult> GetData(string url)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            WebResult result = new WebResult();

            result.Url = url;

            using (HttpClient client = new HttpClient())
            {

                var data = await client.GetAsync(url).ConfigureAwait(false);

                result.ContentSize = data.Content.Headers.ContentLength;
               
            }
            watch.Stop();

            result.TotalMilliseconds = watch.ElapsedMilliseconds;

            return result;
        }
    }
}

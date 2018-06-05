using AsyncAwaitSample.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitSample.Services
{
    public class DataService
    {
        public static DataService Instance { get; }

        private int ThereadId
        {
            get
            {
                return Thread.CurrentThread.ManagedThreadId;
            }
        }

        static DataService()
        {
            Instance = new DataService();
        }

        public async Task<WebResult> GetData(string url)
        {
            
            Debug.WriteLine($"Invoke GetData on thread: {ThereadId}");

            Stopwatch watch = new Stopwatch();
            watch.Start();

            WebResult result = new WebResult();

            result.Url = url;

            using (HttpClient client = new HttpClient())
            {
                Debug.WriteLine($"Getting {url} on thread: {ThereadId}");

                var data = await client.GetAsync(url).ConfigureAwait(false);
                
                Debug.WriteLine($"Continue GetData on thread: {ThereadId}");

                result.ContentSize = data.Content.Headers.ContentLength;
               
            }
            watch.Stop();

            result.TotalMilliseconds = watch.ElapsedMilliseconds;

            return result;
        }
        
        public Task RunLongOperations()
        {
            return Task.Run(async () =>
            {
                Debug.WriteLine($"Invoke RunLongOperations on thread: {ThereadId}");

                await Task.Delay(3000).ConfigureAwait(false);

                Debug.WriteLine($"Continue {nameof(RunLongOperations)} on thread: {ThereadId}");

            });
            
        }
    }
}

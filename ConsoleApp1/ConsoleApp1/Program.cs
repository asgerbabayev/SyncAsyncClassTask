using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<string> urls = new List<string>()
            {
               "https://google.com/",
               "https://facebook.com/",
               "https://github.com"
            };
            HttpClient client = new HttpClient();
            Stopwatch stopwatch = new Stopwatch();
            List<Task<string>> tasks = new List<Task<string>>();
            stopwatch.Start();
            foreach (var url in urls) tasks.Add(client.GetStringAsync(url));
            await Task.WhenAll(tasks);
            stopwatch.Stop();
            foreach (var task in tasks) Console.WriteLine($"{task.Result.Length} -> {stopwatch.ElapsedMilliseconds} milliseconds");
        }
    }
}
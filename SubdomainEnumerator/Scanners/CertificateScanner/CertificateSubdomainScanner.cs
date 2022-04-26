using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace SubdomainEnumerator.Scanners.CertificateScanner
{
    public class CertificateSubdomainScanner : ISubdomainScanner
    {
        private static readonly Regex _certificateSubdomainRegex = new Regex("<TD>([^<]+)</TD>", RegexOptions.IgnoreCase);

        private readonly WebClient _client;
        public CertificateSubdomainScanner()
        {
            _client = new();
        }
        
        public IEnumerable<string> Scan(string targetDomain)
        {
            string content = _client.DownloadString($"https://crt.sh?q={targetDomain}");

            return _certificateSubdomainRegex.Matches(content)
                                             .Select(m => m.Groups[1].Value)
                                             .Select(m => m.Replace("www.", "").Replace("*.", ""))
                                             .Where(s => s.Contains(targetDomain));
        }
    }
}
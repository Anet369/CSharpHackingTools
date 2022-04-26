using System;
using System.Collections.Generic;
using System.Linq;

namespace SubdomainEnumerator.Presenters.Categorizer
{
    public class CategorizationSubdomainPresenter : ISubdomainPresenter
    {
        public void Present(List<string> subdomains)
        {
            PresentKeywordMatch("Testing domains", subdomains, _testKeywords);
            PresentKeywordMatch("Staging domains", subdomains, _stagingKeywords);
            PresentKeywordMatch("Demo domains", subdomains, _demoKeywords);
            PresentKeywordMatch("Management domains", subdomains, _managementKeywords);
            PresentKeywordMatch("Api domains", subdomains, _apiKeywords);
            PresentKeywordMatch("Auth domains", subdomains, _authKeywords);
        }
        public string Name => "Categorizing subdomains";
        private static void PresentKeywordMatch(string title, List<string> subdomains, List<string> keywords)
        {
            List<string> matches = subdomains.Where(sub => keywords.Any(sub.Contains))
                                             .ToList();
            if (matches.Count == 0) return;
            
            Console.WriteLine($"{title} ({matches.Count}):");
            foreach (string match in matches)
            {
                Console.WriteLine($"\t{match}");
            }
        }

        #region Keywords
        private static readonly List<string> _testKeywords = new()
        {
            // "testing",
            "tst",
            "test",
            
            // "development",
            "dev",
            
            // Dansk
            "udv",
            "udvikling",
        };
        private static readonly List<string> _stagingKeywords = new()
        {
            "staging",
            "stage",
            "stg",
        };
        private static readonly List<string> _demoKeywords = new()
        {
            "demo",

            // "preprod",
            // "pre-prod",
            "pre",
            
            "sandbox",
            "sbx",
        };
        private static readonly List<string> _managementKeywords = new()
        {
            "jira",
            "confluence",
            "portal"
        };
        private static readonly List<string> _apiKeywords = new()
        {
            "api",
        };
        private static readonly List<string> _authKeywords = new()
        {
            "sso",
            "admin",
        };
        #endregion
    }
}
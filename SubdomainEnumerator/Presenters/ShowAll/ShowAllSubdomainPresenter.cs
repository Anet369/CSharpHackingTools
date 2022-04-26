using System;
using System.Collections.Generic;

namespace SubdomainEnumerator.Presenters.ShowAll
{
    public class ShowAllSubdomainPresenter : ISubdomainPresenter
    {
        public void Present(List<string> subdomains)
        {
            Console.WriteLine($"Found {subdomains.Count} subdomains:");
            foreach (string subdomain in subdomains)
            {
                Console.WriteLine($"\thttp://{subdomain}");
            }
        }
        public string Name => "All subdomains";
    }
}
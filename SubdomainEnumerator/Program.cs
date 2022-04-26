using System;
using System.Collections.Generic;
using System.Linq;
using SubdomainEnumerator.Extensions;
using SubdomainEnumerator.Presenters;
using SubdomainEnumerator.Presenters.Categorizer;
using SubdomainEnumerator.Presenters.ShowAll;
using SubdomainEnumerator.Presenters.Tree;
using SubdomainEnumerator.Scanners.CertificateScanner;
using SubdomainEnumerator.Scanners.GoogleScanner;

namespace SubdomainEnumerator
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Enter domain name: ");
            string targetDomain = Console.ReadLine();

            // Scanner.Add<GoogleSubdomainScanner>();
            Scanner.Add<CertificateSubdomainScanner>();
            
            Presenter.Add<TreeSubdomainPresenter>();
            Presenter.Add<CategorizationSubdomainPresenter>();
            Presenter.Add<ShowAllSubdomainPresenter>();
            
            List<string> subdomains = Scanner.Scan(targetDomain);
            
            subdomains = subdomains.Distinct()
                                   .Sort()
                                   .ToList();
            
            Presenter.PresentAll(subdomains);
        }
    }
}
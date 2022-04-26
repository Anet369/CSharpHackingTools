using System;
using System.Collections.Generic;
using System.Linq;

namespace SubdomainEnumerator.Presenters.Tree
{
    
    public class TreeSubdomainPresenter : ISubdomainPresenter
    {
        public string Name => "Subdomain tree";
        
        private int _indentation = -1;
        private string Tab => new string(' ', _indentation * 4);

        public void Present(List<string> subdomains)
        {
            List<IGrouping<string, List<string>>> rootDomain = subdomains.Select(sub => sub.Split(".").Reverse().ToList())
                                                                         .GroupBy(sub => sub[0], sub => sub.Skip(1).ToList())
                                                                         .ToList();
            PresentBranchRecursively(rootDomain);
        }
        private void PresentBranchRecursively(List<IGrouping<string, List<string>>> rootDomain)
        {
            _indentation++;
            foreach (IGrouping<string,List<string>> domain in rootDomain)
            {
                Console.WriteLine($"{Tab}{domain.Key}");
                if (!domain.SelectMany(c => c).Any()) continue;
                
                List<IGrouping<string, List<string>>> nextLevel = domain.Where(c => c.Any())
                                                                        .GroupBy(sub => sub[0], sub => sub.Skip(1).ToList())
                                                                        .ToList();
                PresentBranchRecursively(nextLevel);
            }
            _indentation--;
        }
    }
}
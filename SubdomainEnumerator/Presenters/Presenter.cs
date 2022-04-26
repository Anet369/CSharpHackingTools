using System;
using System.Collections.Generic;
using System.Linq;

namespace SubdomainEnumerator.Presenters
{
    public class Presenter
    {
        private static readonly List<ISubdomainPresenter> _presenters = new();

        public static void Add<T>() where T : ISubdomainPresenter, new()
        {
            _presenters.Add(new T());
        }
        public static void PresentAll(List<string> subdomains)
        {
            subdomains = subdomains.Select(s => s.Replace("www.", ""))
                                   .ToList();
            
            foreach (ISubdomainPresenter scanner in _presenters)
            {
                PrintHeader(scanner.Name);
                scanner.Present(subdomains);
            }
        }
        private static void PrintHeader(string scannerName)
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("+" + new string('-', scannerName.Length + 2) + "+");
            Console.WriteLine($"| {scannerName} |");
            Console.WriteLine("+" + new string('-', scannerName.Length + 2) + "+");
        }
    }
}
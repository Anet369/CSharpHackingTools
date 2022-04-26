using System.Collections.Generic;
using SubdomainEnumerator.Scanners;

namespace SubdomainEnumerator
{
    public static class Scanner
    {
        private static readonly List<ISubdomainScanner> _scanners = new();

        public static void Add<T>() where T : ISubdomainScanner, new()
        {
            _scanners.Add(new T());
        }
        public static List<string> Scan(string targetDomain)
        {
            List<string> output = new();
            
            foreach (ISubdomainScanner scanner in _scanners)
            {
                output.AddRange(scanner.Scan(targetDomain));
            }

            return output;
        }
    }
}
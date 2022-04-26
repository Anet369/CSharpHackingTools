using System.Collections.Generic;

namespace SubdomainEnumerator.Scanners
{
    public interface ISubdomainScanner
    {
        IEnumerable<string> Scan(string targetDomain);
    }
}
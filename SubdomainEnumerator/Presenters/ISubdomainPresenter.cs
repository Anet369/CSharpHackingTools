using System.Collections.Generic;

namespace SubdomainEnumerator.Presenters
{
    public interface ISubdomainPresenter
    {
        public void Present(List<string> subdomains);
        public string Name { get; }
    }
}
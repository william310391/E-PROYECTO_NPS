using AppNet6.Core.QueryFilters;
using AppNet6.Infrestructuras.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet6.Infrestructuras.Services
{
    public class UrlService : IUrlService
    {
        private readonly string _baseUri;
        public UrlService(string baseUri)
        {
            _baseUri = baseUri;
        }
        public Uri PaginationUri(ProductoQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }
    }
}

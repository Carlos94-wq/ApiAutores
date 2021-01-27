using Libros.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libros.Infra.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUrl;

        public UriService(string baseUrl)
        {
            this._baseUrl = baseUrl;
        }

        public Uri AutorPagedUrl(string actionUrl)
        {
            string baseUrl = $"{_baseUrl}{actionUrl}";
            return new Uri(baseUrl);
        }
    }
}

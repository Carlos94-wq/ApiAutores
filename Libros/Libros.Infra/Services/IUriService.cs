using System;

namespace Libros.Infra.Services
{
    public interface IUriService
    {
        Uri AutorPagedUrl(string actionUrl);
    }
}
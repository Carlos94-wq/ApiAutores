using Libros.Core.Entities;
using System.Collections.Generic;

namespace Libros.Core.Services
{
    public interface ICategoriaService
    {
        IEnumerable<Categoria> GetCategorias();
    }
}
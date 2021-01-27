using Libros.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libros.Core.Interfaces
{
    public interface ICategoriaRrepository
    {
        IEnumerable<Categoria> GetCategorias();
    }
}

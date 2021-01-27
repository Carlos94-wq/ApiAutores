using Libros.Core.Dtos;
using Libros.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Core.Interfaces
{
    public interface ILibroRepository
    {
        IEnumerable<Libro> GetLibros(int idAutor);
        Task<int> AddBooks(LibroDto dto);
    }
}

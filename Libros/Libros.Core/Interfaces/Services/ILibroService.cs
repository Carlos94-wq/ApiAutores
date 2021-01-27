using Libros.Core.Dtos;
using Libros.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Core.Interfaces.Services
{
    public interface ILibroService
    {
        IEnumerable<Libro> GetLibros(int IdAutor);
        Task<bool> Add(LibroDto dto);
    }
}

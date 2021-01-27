using Libros.Core.Dtos;
using Libros.Core.Entities;
using Libros.Core.Interfaces;
using Libros.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Core.Services
{
    public class LibroService : ILibroService
    {
        private readonly ILibroRepository repository;

        public LibroService(ILibroRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> Add(LibroDto dto)
        {
            var add = await this.repository.AddBooks(dto);
            return add > 0;
        }

        public IEnumerable<Libro> GetLibros(int IdAutor)
        {
            return this.GetLibros(IdAutor);
        }
    }
}

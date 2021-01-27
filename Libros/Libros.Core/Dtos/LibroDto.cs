using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libros.Core.Dtos
{
    public class LibroDto
    {
        public int IdLibro { get; set; }
        public int IdAutor { get; set; }
        public int IdCategoria { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public IFormFile Portada { get; set; }
        public string UrlPortada { get; set; }
    }
}

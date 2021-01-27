using System;
using System.Collections.Generic;
using System.Text;

namespace Libros.Core.Entities
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public Categoria  Categoria { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Portada { get; set; }

        public Libro()
        {
            this.Categoria = new Categoria();
        }
    }
}

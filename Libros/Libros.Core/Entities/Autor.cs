using System;
using System.Collections.Generic;
using System.Text;

namespace Libros.Core.Entities
{
    public class Autor
    {
        public int IdAutor { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNac { get; set; }
        public int Edad { get; set; }
        public bool Activo { get; set; }
        public List<Libro> libros { get; set; }

        public Autor()
        {
            this.libros = new List<Libro>();
        }
    }
}

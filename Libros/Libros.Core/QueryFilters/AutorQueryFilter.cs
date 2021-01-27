using System;
using System.Collections.Generic;
using System.Text;

namespace Libros.Core.QueryFilters
{
    public class AutorQueryFilter
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public bool? Activo { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}

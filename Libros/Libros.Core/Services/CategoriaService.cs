using Libros.Core.Entities;
using Libros.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libros.Core.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRrepository categoria;

        public CategoriaService(ICategoriaRrepository categoria)
        {
            this.categoria = categoria;
        }

        public IEnumerable<Categoria> GetCategorias()
        {
            var All = this.categoria.GetCategorias();
            return All;
        }
    }
}

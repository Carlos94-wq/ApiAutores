using Dapper;
using Libros.Core.Entities;
using Libros.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Libros.Infra.Repository
{
    public class CategoriaRepository : ICategoriaRrepository
    {
        private readonly IDbConnection db;

        public CategoriaRepository(IDbConnection db)
        {
            this.db = db;
        }

        public IEnumerable<Categoria> GetCategorias()
        {
            using (var conn = this.db)
            {
                conn.Open();

                var categorias = this.db.Query<Categoria>(
                    sql: "SELECT * FROM Categoria"
                );

                return categorias;
            }
        }
    }
}

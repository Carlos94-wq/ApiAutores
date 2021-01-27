using Dapper;
using Libros.Core.Dtos;
using Libros.Core.Entities;
using Libros.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Infra.Repository
{
    public class LibroRepository : ILibroRepository
    {
        private readonly IDbConnection db;

        public LibroRepository(IDbConnection db)
        {
            this.db = db;
        }

        public async Task<int> AddBooks(LibroDto dto)
        {
            using (var con = this.db)
            {
                con.Open();

                var Add = await this.db.ExecuteAsync(
                sql: "spLibro",
                commandType: CommandType.StoredProcedure,
                param: new
                {
                    Accion = 3,
                    IdAutor = dto.IdAutor,
                    IdCategoria = dto.IdCategoria,
                    Titulo = dto.Titulo,
                    Descripcion = dto.Descripcion,
                    Portada = dto.UrlPortada

                }).ConfigureAwait(false);

                return Add;
            }
        }

        public IEnumerable<Libro> GetLibros(int idAutor)
        {
            using (var conn = this.db)
            {
                conn.Open();

                var lib = this.db.Query<Libro>(
                    sql: "spLibros",
                    commandType: CommandType.StoredProcedure,
                    param: new
                    {
                        Accion = 4,
                        idAutor = idAutor
                    }
                );

                return lib;
            }
        }
    }
}

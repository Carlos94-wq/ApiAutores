using Dapper;
using Libros.Core.CustomEntities;
using Libros.Core.Dtos;
using Libros.Core.Entities;
using Libros.Core.Interfaces;
using Libros.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Infra.Repository
{
    public class AutorRepository : IAutorRepository
    {
        private readonly IDbConnection db;

        public AutorRepository(IDbConnection db)
        {
            this.db = db;
        }

        public IEnumerable<AutorViewModel> GetAll(AutorQueryFilter filter)
        {
            using (var con = this.db)
            {
                con.Open();
                var PagedList = this.db.Query<AutorViewModel>(
                    sql: "spAutor",
                    commandType: CommandType.StoredProcedure,
                    param: new
                    {
                        Accion = 1,
                        Nombre = filter.Nombre,
                        Apellidos = filter.Apellidos,
                        Activo = filter.Activo
                    }
                );

                return PagedList;
            }
        }

        public async Task<Autor> GetAutor(int id)
        {
            using (var con = this.db )
            {
                con.Open();

                var autor = await this.db.QueryAsync<Autor>(
                    sql: "spAutor",
                    commandType: CommandType.StoredProcedure,
                    param: new
                    {
                        Accion = 2,
                        IdAutor = id
                    }

                ).ConfigureAwait(false);

                var libros = await this.db.QueryAsync<Libro, Categoria, Libro>(
                    sql: "spAutor",
                    commandType: CommandType.StoredProcedure,
                    map: (L, c) =>
                    {
                        L.Categoria = c;
                        return L;
                    },
                    splitOn:"IdCategoria",
                    param: new
                    {
                        Accion = 6,
                        IdAutor = autor.FirstOrDefault().IdAutor
                    }
                ).ConfigureAwait(false);

                autor.FirstOrDefault().libros = libros.ToList();
                return autor.FirstOrDefault();
            }
        }

        public async Task<int> Add(AutorDto dto)
        {
            using (var con = this.db)
            {
                con.Open();

                var Add = await this.db.ExecuteAsync(
                sql: "spAutor", 
                commandType: CommandType.StoredProcedure,
                param: new
                {
                    Accion = 5,
                    Nombre = dto.Nombre,
                    Apellidos = dto.Apellidos,
                    FechaNac = dto.FechaNac,
                    Edad = dto.Edad

                }).ConfigureAwait(false);

                return Add;
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var con = this.db)
            {
                con.Open();

                var Update = await this.db.ExecuteAsync(
                sql: "spAutor",
                commandType: CommandType.StoredProcedure,
                param: new
                {
                    Accion = 4,
                    IdAutor = id

                }).ConfigureAwait(false);

                return Update;
            }
        }

        public async Task<int> Update(AutorDto dto)
        {
            using (var con = this.db)
            {
                con.Open();

                var Update = await this.db.ExecuteAsync(
                sql: "spAutor",
                commandType: CommandType.StoredProcedure,
                param: new
                {
                    Accion = 3,
                    IdAutor = dto.IdAutor,
                    Nombre = dto.Nombre,
                    Apellidos = dto.Apellidos,
                    FechaNac = dto.FechaNac,
                    Edad = dto.Edad

                }).ConfigureAwait(false);

                return Update;
            }
        }
    }
}

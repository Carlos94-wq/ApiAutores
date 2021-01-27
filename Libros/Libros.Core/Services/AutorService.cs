using Libros.Core.CustomEntities;
using Libros.Core.Dtos;
using Libros.Core.Entities;
using Libros.Core.Interfaces;
using Libros.Core.Interfaces.Services;
using Libros.Core.QueryFilters;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Core.Services
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository repository;
        private readonly PaginationOptions _options;

        public AutorService(IAutorRepository repository, IOptions<PaginationOptions> options)
        {
            this.repository = repository;
            this._options = options.Value;
        }

        public PagedList<AutorViewModel> GetAll(AutorQueryFilter filter)
        {
            filter.PageNumber = filter.PageNumber == 0 ? this._options.DefaultPageNumber : filter.PageNumber;
            filter.PageSize = filter.PageSize == 0 ? this._options.DefaultPageSize : filter.PageSize;

            var All = this.repository.GetAll(filter);
            return PagedList<AutorViewModel>.Create(All, filter.PageNumber, filter.PageSize);
        }

        public async Task<Autor> GetAutor(int id)
        {
            return await this.repository.GetAutor(id);
        }

        public async Task<bool> Add(AutorDto dto)
        {
            var IsAdded = await this.repository.Add(dto);
            return IsAdded > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var IsDeleted = await this.repository.Delete(id);
            return IsDeleted > 0;
        }

        public async Task<bool> Update(AutorDto dto)
        {
            var IsUpdatede = await this.repository.Update(dto);
            return IsUpdatede > 0;
        }
    }
}

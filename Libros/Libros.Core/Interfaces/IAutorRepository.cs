using Libros.Core.CustomEntities;
using Libros.Core.Dtos;
using Libros.Core.Entities;
using Libros.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Libros.Core.Interfaces
{
    public interface IAutorRepository
    {
        IEnumerable<AutorViewModel> GetAll(AutorQueryFilter filter);
        Task<Autor> GetAutor(int id);
        Task<int> Add(AutorDto dto);
        Task<int> Update(AutorDto dto);
        Task<int> Delete(int id);
    }
}

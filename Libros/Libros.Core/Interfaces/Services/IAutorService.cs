using Libros.Core.CustomEntities;
using Libros.Core.Dtos;
using Libros.Core.Entities;
using Libros.Core.QueryFilters;
using System.Threading.Tasks;

namespace Libros.Core.Interfaces.Services
{
    public interface IAutorService
    {
        Task<bool> Add(AutorDto dto);
        Task<bool> Delete(int id);
        PagedList<AutorViewModel> GetAll(AutorQueryFilter filter);
        Task<Autor> GetAutor(int id);
        Task<bool> Update(AutorDto dto);
    }
}
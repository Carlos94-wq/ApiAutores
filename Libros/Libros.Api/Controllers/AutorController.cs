using Libros.Api.Responses;
using Libros.Core.CustomEntities;
using Libros.Core.Dtos;
using Libros.Core.Entities;
using Libros.Core.Interfaces.Services;
using Libros.Core.QueryFilters;
using Libros.Infra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService autor;
        private readonly IUriService uri;

        public AutorController(IAutorService autor, IUriService uri)
        {
            this.autor = autor;
            this.uri = uri;
        }

        [HttpGet(Name = nameof(GetAutores))]
        public IActionResult GetAutores([FromQuery] AutorQueryFilter filter)
        {
            var All = this.autor.GetAll(filter);
            var metada = new MetaData
            {
                TotalCount = All.TotalCount,
                PageSize = All.PageSize,
                CurrentPage = All.CurrentPage,
                TotalPages = All.TotalPages,
                HasNextPage = All.HasNextPage,
                HasPreviousPage = All.HasPreviousPage,
                NextPageUrl = uri.AutorPagedUrl(Url.RouteUrl(nameof(GetAutores))).ToString(),
                PreviousPageUrl = uri.AutorPagedUrl(Url.RouteUrl(nameof(GetAutores))).ToString()
            };
            var response = new ApiResponse<IEnumerable<AutorViewModel>>(All)
            {
                Meta = metada
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Autor = await this.autor.GetAutor(id);
            var response = new ApiResponse<Autor>(Autor);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AutorDto dto)
        {
            var Autor = await this.autor.Add(dto);
            var response = new ApiResponse<bool>(Autor);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Autor = await this.autor.Delete(id);
            var response = new ApiResponse<bool>(Autor);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AutorDto dto)
        {
            var Autor = await this.autor.Update(dto);
            var response = new ApiResponse<bool>(Autor);

            return Ok(response);
        }

    }
}

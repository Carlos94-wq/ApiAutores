using Libros.Api.Responses;
using Libros.Core.Entities;
using Libros.Core.Services;
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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService service;

        public CategoriaController(ICategoriaService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetCategorias()
        {
            var all = this.service.GetCategorias();
            var respone = new ApiResponse<IEnumerable<Categoria>>(all);

            return Ok(respone);
        }
    }
}

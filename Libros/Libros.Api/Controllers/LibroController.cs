using Libros.Api.Interfaces;
using Libros.Api.Responses;
using Libros.Core.Dtos;
using Libros.Core.Entities;
using Libros.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Libros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly IUploadFiles upload;
        private readonly ILibroService service;
        private readonly string Folder = "Portadas";

        public LibroController(IUploadFiles upload, ILibroService service)
        {
            this.upload = upload;
            this.service = service;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           
            var libros = this.service.GetLibros(id);
            var response = new ApiResponse<IEnumerable<Libro>>(libros);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] LibroDto dto)
        {
            using (var stream = new MemoryStream())
            {
                await dto.Portada.CopyToAsync(stream);
                var contenido = stream.ToArray();
                var extension = Path.GetExtension(dto.Portada.FileName);
                dto.UrlPortada = await upload.Upload(contenido, extension, Folder, dto.Portada.ContentType);
            }

            var add = await this.service.Add(dto);
            var response = new ApiResponse<bool>(add);

            return Ok(response);
        }
    }
}

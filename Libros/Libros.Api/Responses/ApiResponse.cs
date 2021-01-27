using Libros.Core.CustomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libros.Api.Responses
{
    public class ApiResponse<T>
    {
        public T Data  { get; set; }
        public MetaData Meta { get; set; }

        public ApiResponse(T data)
        {
            this.Data = data;
        }
    }
}

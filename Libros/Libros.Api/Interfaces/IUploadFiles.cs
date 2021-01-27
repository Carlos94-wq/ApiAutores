using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libros.Api.Interfaces
{
    public interface IUploadFiles
    {
        Task<string> Upload(byte[] contenido, string extension, string contenendor, string ConentType);
    }
}

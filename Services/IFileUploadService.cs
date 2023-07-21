using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadExcelFile.Services;

public interface IFileUploadService
{
    Task<string> UploadExcelFile(IFormFile file); 
}
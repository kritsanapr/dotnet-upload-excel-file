using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReadExcelFile.Services;

namespace ReadExcelFile.Controllers;

[Route("[controller]")]
public class UploadFileController : ControllerBase
{
    private readonly IFileUploadService _fileUploadService;
    public UploadFileController(IFileUploadService fileUploadService)
    {
        _fileUploadService = fileUploadService;
    }
    

    [HttpPost]
   public async Task<IActionResult> UploadFile(IFormFile file)
    {
        var result = await _fileUploadService.UploadExcelFile(file);
        if (result.Contains("successfully"))
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
    [Route("upload")]
   public async Task<IActionResult> UploadFile(IFormFile file)
    {
        var result = await _fileUploadService.UploadExcelFile(file);
        if (result.Contains("successfully"))
        {
            return Ok(result);
        }

        return BadRequest(result);
    }


    [HttpGet]
    [Route("export")]
    public async Task<IActionResult> ExportFile() {
        var data = await _fileUploadService.GetAll();
        if(data == null)
        {
            return BadRequest("No data found");
        }

        var builder = new StringBuilder();
        builder.AppendLine("Name,Data");
        foreach(var item in data)
        {
            builder.AppendLine($"{item.Name},{item.Data}");
        }

        return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "export.csv");
    }
}
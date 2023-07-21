using System.ComponentModel.DataAnnotations;
using ReadExcelFile.Models;

namespace ReadExcelFile.Data;

public class Upload : BaseEntity
{
    [Required]
    public string Name { get; set; } = default!;
    
    [Required]
    public string Data { get; set; } = default!;
}
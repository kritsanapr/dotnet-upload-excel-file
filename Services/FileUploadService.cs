using OfficeOpenXml;
using ReadExcelFile.Data;


namespace ReadExcelFile.Services;

public class FileUploadService : IFileUploadService
    {
        private readonly ApplicationDbContext _context;

        public FileUploadService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> UploadExcelFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return "Please upload a valid Excel file";

            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);

            using var package = new ExcelPackage(stream);

            if (package.Workbook.Worksheets.Count == 0)
                return "The uploaded file does not contain any worksheets.";

            var worksheet = package.Workbook.Worksheets[0];

            if (worksheet.Dimension == null)
                return "The worksheet is empty.";

            int rowCount = worksheet.Dimension.Rows;

            for (int row = 2; row <= rowCount; row++)
            {
                var entity = new Upload
                {
                    Name = worksheet.Cells[row, 1].Value?.ToString().Trim() ?? string.Empty,
                    Data = worksheet.Cells[row, 2].Value?.ToString().Trim() ?? string.Empty
                };

                _context.Uploads.Add(entity);
            }

            await _context.SaveChangesAsync();

            return "Excel data has been imported successfully!";
        }
    }
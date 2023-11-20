namespace Store.Api.Ingestion.Controllers;

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Ingestion.Managers;
using Store.Api.Ingestion.Services.Upload;

[ApiController]
[Route("api/[controller]")]
public class IngestionController : ControllerBase
{
    private const string CsvFileContentType = "text/csv";
    private readonly IIngestionManager _iIngestionManager;

    public IngestionController(IIngestionManager iIngestionManager) => _iIngestionManager = iIngestionManager;

    [HttpPost]
    [Route("ingestion")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> IngestAsync(IFormFile file)
    {
        if (!file.ContentType.Equals(CsvFileContentType, StringComparison.OrdinalIgnoreCase))
        {
            return BadRequest("Only upload CSV file.");
        }
        try
        {
            await _iIngestionManager.HandleIngestionAsync(file);
            return Ok($"Your file {file.FileName} has been successfully uploaded.");

        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex}");
        }
    }

    [HttpPost]
    [Route("multple-ingestion")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> IngestMultipleAsync(IFormFileCollection files)
    {
        if (files.Count == 0)
        {
            return BadRequest("No files selected.");
        }
        if (files.Any(file => !file.ContentType.Equals(CsvFileContentType, StringComparison.OrdinalIgnoreCase)))
        {
            return BadRequest("Only upload CSV files.");
        }

        try
        {
            await _iIngestionManager.HandleMultipleIngestionAsync(files);
            return Ok($"Your files have been successfully uploaded.");
        }

        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex}");
        }


    }
}

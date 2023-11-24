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
    public async Task<IActionResult> IngestAsync()
    {
        var formCollection = await Request.ReadFormAsync();
        var file = formCollection.Files.First();
        if (file.Length > 0)
        {
            return BadRequest("Empty file!");
        }
        if (!file.ContentType.Equals(CsvFileContentType, StringComparison.OrdinalIgnoreCase))
        {
            return BadRequest("Only upload CSV file.");
        }
        try
        {
            await _iIngestionManager.HandleIngestionAsync(file);
            return Ok();

        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex}");
        }
    }

    [HttpPost]
    [Route("multiple-ingestion")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> IngestMultipleAsync()
    {
        var formCollection = await Request.ReadFormAsync();
        var files = formCollection.Files;
        if (files.Any(f => f.Length == 0))
        {
            return BadRequest("A few files are not having any records");
        }
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
            return Ok();
        }

        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex}");
        }


    }
}

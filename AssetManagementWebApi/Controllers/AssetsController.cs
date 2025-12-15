using AssetManagementWebApi.DTO;
using AssetManagementWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetService _assetService;

        public AssetsController(IAssetService assetService)
        {
            _assetService = assetService;
        }


        [HttpPost("books")]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookDto dto)
        {
            var book = await _assetService.CreateBookAsync(dto);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        [HttpGet("books")]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _assetService.GetBooksAsync();
            return Ok(books);
        }

        [HttpGet("books/{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _assetService.GetBookByIdAsync(id);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpPut("books/{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookDto dto)
        {
            var updated = await _assetService.UpdateBookAsync(id, dto);
            return Ok(updated);
        }

        [HttpDelete("books/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _assetService.DeleteBookAsync(id);
            return NoContent();
        }


        [HttpPost("hardware")]
        public async Task<IActionResult> CreateHardware([FromBody] CreateHardwareDto dto)
        {
            var hw = await _assetService.CreateHardwareAsync(dto);
            return CreatedAtAction(nameof(GetHardwareById), new { id = hw.Id }, hw);
        }

        [HttpGet("hardware")]
        public async Task<IActionResult> GetHardware()
        {
            var hardware = await _assetService.GetHardwareAsync();
            return Ok(hardware);
        }

        [HttpGet("hardware/{id}")]
        public async Task<IActionResult> GetHardwareById(int id)
        {
            var hw = await _assetService.GetHardwareByIdAsync(id);
            return hw == null ? NotFound() : Ok(hw);
        }

        [HttpPut("hardware/{id}")]
        public async Task<IActionResult> UpdateHardware(int id, [FromBody] UpdateHardwareDto dto)
        {
            var updated = await _assetService.UpdateHardwareAsync(id, dto);
            return Ok(updated);
        }

        [HttpDelete("hardware/{id}")]
        public async Task<IActionResult> DeleteHardware(int id)
        {
            await _assetService.DeleteHardwareAsync(id);
            return NoContent();
        }


        [HttpPost("software")]
        public async Task<IActionResult> CreateSoftware([FromBody] CreateSoftwareDto dto)
        {
            var sw = await _assetService.CreateSoftwareAsync(dto);
            return CreatedAtAction(nameof(GetSoftwareById), new { id = sw.Id }, sw);
        }

        [HttpGet("software")]
        public async Task<IActionResult> GetSoftware()
        {
            var software = await _assetService.GetSoftwareAsync();
            return Ok(software);
        }

        [HttpGet("software/{id}")]
        public async Task<IActionResult> GetSoftwareById(int id)
        {
            var sw = await _assetService.GetSoftwareByIdAsync(id);
            return sw == null ? NotFound() : Ok(sw);
        }

        [HttpPut("software/{id}")]
        public async Task<IActionResult> UpdateSoftware(int id, [FromBody] UpdateSoftwareDto dto)
        {
            var updated = await _assetService.UpdateSoftwareAsync(id, dto);
            return Ok(updated);
        }

        [HttpDelete("software/{id}")]
        public async Task<IActionResult> DeleteSoftware(int id)
        {
            await _assetService.DeleteSoftwareAsync(id);
            return NoContent();
        }
    }
}

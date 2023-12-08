using Healthcare.API.Data;
using Healthcare.API.DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCareAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MedicinesController(AppDbContext context, IWebHostEnvironment environment)
    : ControllerBase
{
    private readonly AppDbContext _context = context;
    private IWebHostEnvironment _environment = environment;

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMedicine(int id, [FromForm] MedicineModel model)
    {
        var medicine = await _context.Medicines.SingleOrDefaultAsync(m => m.MedicineId == id);
        if (medicine == null)
            return BadRequest("No medicine founded!!");

        var path = GetImagePath();

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        var extension = Path.GetExtension(model.Image.FileName);

        using var memoryStream = new MemoryStream();
        await model.Image.CopyToAsync(memoryStream);

        var imageName = DateTime.Now.ToString("yyyyMMddhhmmss") + extension;

        var fileWithName = Path.Combine(path, imageName);

        using var stream = new FileStream(fileWithName, FileMode.Create);
        model.Image.CopyTo(stream);

        var hostUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";

        var imageUrl = Path.Combine(hostUrl, $"Uploads/{imageName}");

        medicine.Image = memoryStream.ToArray();
        medicine.ImagePath = imageUrl;


        _context.Medicines.Update(medicine);
        await _context.SaveChangesAsync();

        return Ok(medicine);
    }

    [NonAction]
    private string GetImagePath()
    {
        var path = Path.Combine(_environment.WebRootPath, "Uploads");
        return path;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMedicineAsync(int id)
    {
        var medicine = await
            _context.Medicines.SingleOrDefaultAsync(m => m.MedicineId == id);

        if (medicine == null)
            return NotFound($"No medicine founded with id ${id}");

        _context.Medicines.Remove(medicine);

        await _context.SaveChangesAsync();

        return Ok(medicine);

    }

    [HttpGet("GetMedicineImageBlob")]
    public async Task<IActionResult> GetMedicineImageBlob(int id)
    {
        var medicine = await _context.Medicines.SingleOrDefaultAsync(e => e.MedicineId == id);

        if (medicine is null || medicine.Image == null)
            return NotFound("Not founded !!!");

        return File(medicine.Image!, "application/octet-stream");

    }
}

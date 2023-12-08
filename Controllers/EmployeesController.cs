using Healthcare.API.Data;
using Healthcare.API.DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCareAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeesController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
    : ControllerBase
{
    private readonly AppDbContext _context = context;
    private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(int id, [FromForm] EmployeeDto model)
    {
        var employee = await _context.Employees.SingleOrDefaultAsync(m => m.EmployeeId == id);
        if (employee == null)
            return BadRequest("No employee founded!!");

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

        employee.Image = memoryStream.ToArray();
        employee.ImageUrl = imageUrl;


        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();

        return Ok(employee);
    }

    [NonAction]
    private string GetImagePath()
    {
        var path = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads");
        return path;
    }


    [HttpGet("GetEmployeeImageBlob")]
    public async Task<IActionResult> GetEmployeeImageAsync(int id)
    {
        var employee = await _context.Employees.SingleOrDefaultAsync(e => e.EmployeeId == id);

        if (employee is null || employee.Image == null)
            return NotFound("Not founded !!!");

        return File(employee.Image!, "application/octet-stream");

    }
}

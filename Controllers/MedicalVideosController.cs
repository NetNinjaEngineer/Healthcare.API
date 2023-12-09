using Healthcare.API.Data;
using Healthcare.API.DTOS;
using Healthcare.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCareAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MedicalVideosController(AppDbContext context, IWebHostEnvironment webHostEnvironment) : ControllerBase
{
    private readonly AppDbContext _context = context;
    private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

    [HttpPost("UploadMedicalVideo")]
    public async Task<IActionResult> UploadMedicalVideoAsync([FromForm] MedicalVideoModel model)
    {
        var validDepartmentId = _context.Departments.Any(d => d.DepartmentId == model.DepartmentId);

        if (!validDepartmentId && model.DepartmentId.HasValue)
            return NotFound($"There is no department with id: ${model.DepartmentId}");

        var path = Path.Combine(_webHostEnvironment.WebRootPath, "Videos");
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        if (model.Video?.Length > 0)
        {
            var videoExtension = Path.GetExtension(model.Video.FileName);

            var allowedExtensions = new List<string> { ".mp4" };

            if (!allowedExtensions.Contains(videoExtension))
                return BadRequest("Only allowed extensions .mp4");

            var videoName = DateTime.Now.ToString("yyyyMMddhhmmss") + videoExtension; // video.mp4

            var completeVideoPath = Path.Combine(path, videoName);

            if (System.IO.File.Exists(completeVideoPath))
                System.IO.File.Delete(completeVideoPath);

            using (var stream = new FileStream(completeVideoPath, FileMode.Create))
            {
                await model.Video.CopyToAsync(stream);
            }

            var hostUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
            var videoPath = Path.Combine(hostUrl, $"Videos/{videoName}");

            using var memoryStream = new MemoryStream();
            await model.Video.CopyToAsync(memoryStream);

            var medicalVideo = new MedicalVideo
            {
                Path = videoPath,
                Title = model.Title,
                Video = memoryStream.ToArray(),
                Description = model.Description,
                DepartmentId = model.DepartmentId
            };

            _context.MedicalVideos.Add(medicalVideo);

            await _context.SaveChangesAsync();

            return Ok(medicalVideo);

        }
        else
            return BadRequest("Length of video must be greater zero");
    }

    [HttpGet("GetMedicalVideos")]
    public async Task<IActionResult> GetMedicalVideosAsync()
    {
        var medicalVideos = await _context.MedicalVideos.Include(m => m.Department)
            .Select(x => new
            {
                x.Id,
                x.Title,
                x.Description,
                x.DepartmentId,
                x.Path
            })
            .ToListAsync();

        return Ok(medicalVideos);

    }

    [NonAction]
    private async Task<string> ConvertVideoToBase64(string videoPath)
    {
        byte[] videoBytes = await System.IO.File.ReadAllBytesAsync(videoPath);
        var base64String = Convert.ToBase64String(videoBytes);
        return base64String;
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetMedicalVideoBlobAsync(int id)
    {
        var medicalVideos = await _context.MedicalVideos.Include(m => m.Department)
            .ToListAsync();

        var video = medicalVideos.SingleOrDefault(m => m.Id == id);

        if (video == null)
            return NotFound("Not founded !!!");

        return File(video.Video!, "application/octet-stream");

    }
}

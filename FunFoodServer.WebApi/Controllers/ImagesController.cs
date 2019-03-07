using System;
using Microsoft.AspNetCore.Mvc;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using FunFoodServer.WebApi.Helpers;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace FunFoodServer.WebApi.Controllers
{
  [ApiController]
  [Route("api/v1/[controller]")]
  public class ImagesController : ControllerBase
  {
    private readonly Cloudinary _cloudinary;

    private readonly CloudinaryConfig _cloudinaryConfig;

    private readonly IHostingEnvironment _iHostEnvironment;

    public ImagesController(IOptions<CloudinaryConfig> options, IHostingEnvironment env)
    {
      _cloudinaryConfig = options.Value;
      _iHostEnvironment = env;

      var cloudinaryAccount = new Account(
        _cloudinaryConfig.CloudName,
        _cloudinaryConfig.ApiKey,
        _cloudinaryConfig.ApiSecret);

      _cloudinary = new Cloudinary(cloudinaryAccount);
    }

    // Post: api/v1/images/upload
    [HttpPost("upload")]
    public IActionResult Upload()
    {
      var files = Request.Form.Files;
      if (files == null)
        return BadRequest("No file has been upload in request.");

      var image = files[0];
      var size = image.Length;
      if (size > 0)
      {
        // save image to upload folder
        var fileExt = UtilityOfUpload.GetFileExt(files[0].Name);
        var newFileName = $"{Guid.NewGuid().ToString()}.{fileExt}";
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "upload", newFileName);
        try
        {
          using (var stream = new FileStream(filePath, FileMode.Create))
          {
            image.CopyTo(stream);
          }
        }
        catch (Exception ex)
        {
          return BadRequest($"Backend error: {ex.Message}");
        }

        // upload images to a specific folder on cloudinary
        var uploadParams = new ImageUploadParams()
        {
          File = new FileDescription(filePath),
          PublicId = $"{_cloudinaryConfig.ProcessFolder}/{newFileName}",
        };
        var uploadResult = _cloudinary.Upload(uploadParams);

        // remove local image from upload folder
        System.IO.File.Delete(filePath);

        return Ok(uploadResult.JsonObj);

      }

      return BadRequest("Image cannot be empty.");
    }

    // Post: api/v1/images/destroy
    [HttpGet("destroy/{desc}")]
    public IActionResult Destroy(string desc)
    {
      if (string.IsNullOrWhiteSpace(desc))
        return BadRequest("The format of request data is not correct.");

      var deletionParam = new DeletionParams(desc);
      DeletionResult deletionResult =_cloudinary.Destroy(deletionParam);
      if (deletionResult.Result.Equals("ok"))
        return Ok();        

      return BadRequest("Deletion failed as server internal error.");
    }
  }
}

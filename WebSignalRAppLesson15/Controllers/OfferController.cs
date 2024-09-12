using Microsoft.AspNetCore.Mvc;
using WebSignalRAppLesson15.Helpers;

namespace WebSignalRAppLesson15.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OfferController : ControllerBase
{
    // GET: api/<OfferController>
    [HttpGet]
    public double Get()
    {
        return FileHelper.Read();
    }

    [HttpGet("Increase")]
    public void IncreaseOffer(double data)
    {
        var result = FileHelper.Read() + data;
        FileHelper.Write(result);
    }
}

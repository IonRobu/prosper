using Methodic.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IndexController : ApiController
{
    [HttpGet("check")]
    public ActionResult Index()
    {
       return Result("OK");
    }
}

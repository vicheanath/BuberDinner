
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("[controller]")]
[Authorize]
public class DinnersController : ApiController
{
    [HttpGet]
    public IActionResult List()
    {
        return Ok(Array.Empty<string>());
    }

}
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ErrorController : ControllerBase
{
    [HttpGet("not-found")]
    public IActionResult NotFoundError()
    {
        return NotFound();
    }

    [HttpGet("bad-request")]
    public IActionResult BadRequestError()
    {
        return BadRequest();
    }

    [HttpGet("unauthorized")]
    public IActionResult UnauthorizedError()
    {
        return Unauthorized();
    }

    [HttpGet("validation-error")]
    public IActionResult ValidationError()
    {
        ModelState.AddModelError("validationError 1", "This is a validation error");
        ModelState.AddModelError("validationError 2", "This is a second validation error");
        return ValidationProblem();
    }

    [HttpGet("server-error")]
    public IActionResult ServerError()
    {
        throw new Exception("This is a server error");
    }
}
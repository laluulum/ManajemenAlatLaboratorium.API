using Microsoft.AspNetCore.Mvc;

namespace ManajemenAlatLaboratorium.API.Controllers;

public class ErrorController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}
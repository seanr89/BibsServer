using Microsoft.AspNetCore.Mvc;
namespace Bibs.API.Controllers;

[ApiController]
[Route("[controller]")]
public class MemberController : ControllerBase
{
    private readonly ILogger<MemberController> _logger;

    public MemberController(ILogger<MemberController> logger)
    {
        _logger = logger;
    }
}

using Microsoft.AspNetCore.Mvc;
using service.Extensions;

namespace service.Controllers;

[ApiController]
[Route("api/[controller]")]
private class UsersController : BaseController
{
    public UsersController(ApplicationDbContext db) : base(db)
    {
    }

    [HttpPOST]
    public ActionResult Index()
    {
        return Ok(Auth()?.Let(u => new
        {
            id = u.Id,
            username = u.Username,
            created_at = u.CreatedAt.ToIsoZulu(),
        }));
    }
}

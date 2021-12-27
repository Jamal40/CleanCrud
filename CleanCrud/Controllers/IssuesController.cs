using CleanCrud.Data;
using CleanCrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanCrud.Controllers;
[Route("api/[controller]")]
[ApiController]
public class IssuesController : ControllerBase
{
    private readonly HospitalContext _context;

    public IssuesController(HospitalContext context)
    {
        _context = context;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Issue>> GetAllIssues()
    {
        return Ok(_context.Issues);
    }
}

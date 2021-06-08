using GCD0804TodoManagement.Models;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace GCD0804TodoManagement.Controllers.Api
{
  public class TeamsController : ApiController
  {
    private ApplicationDbContext _context;
    public TeamsController()
    {
      _context = new ApplicationDbContext();
    }
    [HttpGet]
    public IHttpActionResult GetAll()
    {
      var teams = _context.Teams.ToList();
      return Ok(teams);
    }
    [HttpGet]
    public IHttpActionResult GetById(int id)
    {
      var team = _context.Teams.SingleOrDefault(t => t.Id == id);
      if (team == null) return NotFound();

      return Ok(team);
    }

    [HttpPost]
    public IHttpActionResult Create([FromBody] Team model)
    {
      var newTeam = new Team
      {
        Name = model.Name
      };

      _context.Teams.Add(newTeam);
      _context.SaveChanges();

      return StatusCode(HttpStatusCode.Created);
    }

    [HttpDelete]
    public IHttpActionResult Delete(int id)
    {
      var team = _context.Teams.SingleOrDefault(t => t.Id == id);

      if (team == null) return NotFound();

      _context.Teams.Remove(team);
      _context.SaveChanges();

      return Ok("Deleted ...");
    }

    [HttpPut]
    public IHttpActionResult Edit(int id, [FromBody] Team model)
    {
      var team = _context.Teams.SingleOrDefault(t => t.Id == id);

      if (team == null) return NotFound();

      team.Name = model.Name;
      _context.SaveChanges();

      return Ok("Updated ...");
    }
  }
}

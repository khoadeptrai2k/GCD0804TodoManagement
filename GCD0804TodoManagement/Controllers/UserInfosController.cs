using GCD0804TodoManagement.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace GCD0804TodoManagement.Controllers
{
  [Authorize]
  public class UserInfosController : Controller
  {
    private ApplicationDbContext _context;
    public UserInfosController()
    {
      _context = new ApplicationDbContext();
    }
    // GET: UserInfos
    public ActionResult Index()
    {
      var userId = User.Identity.GetUserId();
      var userInfo = _context.UserInfos.SingleOrDefault(u => u.UserId.Equals(userId));

      if (userInfo == null) return HttpNotFound();
      return View(userInfo);
    }

    [HttpGet]
    public ActionResult Edit()
    {
      var userId = User.Identity.GetUserId();
      var userInfo = _context.UserInfos.SingleOrDefault(u => u.UserId.Equals(userId));

      if (userInfo == null) return HttpNotFound();
      return View(userInfo);
    }
  }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers;

[Area("Admin"),Authorize]
public class MainController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entities.Models;
using OtoServisSatis.Service.Abstract;
using OtoServisSatis.WebUI.Models;

namespace OtoServisSatis.WebUI.Controllers;

public class HomeController : Controller
{
    private readonly IService<Slider> _service;
    private readonly IService<Arac> _serviceArac;

    public HomeController(IService<Slider> service, IService<Arac> serviceArac)
    {
        _service = service;
        _serviceArac = serviceArac;
    }


    public async Task<IActionResult> Index()
    {
        var model = new HomePageViewModel()
        {
           Sliders =  await _service.GetAllAsynch(),
           Araclar = await _serviceArac.GetAllAsynch(a => a.Anasayfa)
        };

        return View(model);


    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
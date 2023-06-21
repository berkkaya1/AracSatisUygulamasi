using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entities.Models;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly IService<Kullanici> _service;

        public LoginController(IService<Kullanici> service)
        {
            _service = service;
        }

        //GET
        public IActionResult Index()
        {
            return View();
        }
        
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Admin/Login");
        }

        
        //POST
        [HttpPost]
        public async Task<IActionResult> Index(string email, string password)
        {
            try
            {
                var account = _service.Get(k => k.Email == email && k.Sifre == password && k.AktifMi == true);

                if (account == null)
                {
                    TempData["Mesaj"] = "Giris Basarisiz";
                }
                else
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,account.Ad),
                        new Claim("Role","Admin")
                    };
                    var userIdentity = new ClaimsIdentity(claims,"Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    return Redirect("/Admin");
                }
                
            }
            catch (Exception e)
            {
                TempData["Mesaj"] = "Hata Olustu";
            }
            return View();
        }
    }
}
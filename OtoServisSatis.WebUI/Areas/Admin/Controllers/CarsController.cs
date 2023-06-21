using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using OtoServisSatis.Entities.Models;
using OtoServisSatis.Service.Abstract;
using OtoServisSatis.WebUI.Utils;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]
    public class CarsController : Controller
    {
        private readonly IService<Arac> _service;
        private readonly IService<Marka> _serviceMarka;

        public CarsController(IService<Arac> service, IService<Marka> serviceMarka)
        {
            _service = service;
            _serviceMarka = serviceMarka;
        }

        // GET: Cars
        public async Task<IActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsynch();
            return View(model);
        }

        // GET: Cars/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cars/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsynch(),"Id","Ad");
            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Arac arac, IFormFile? Resim1, IFormFile? Resim2, IFormFile? Resim3)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    arac.Resim1 = await FileHelper.FileLoaderAsync(Resim1,"/Img/Cars/");
                    arac.Resim2 = await FileHelper.FileLoaderAsync(Resim2, "/Img/Cars/");
                    arac.Resim3 = await FileHelper.FileLoaderAsync(Resim3,"/Img/Cars/");
                   await _service.AddAsync(arac);
                   await _service.SaveAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("","Hata Olustu");
                }
                
            }
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsynch(),"Id","Ad");
            return View(arac);
           
        }

        // GET: Cars/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsynch(),"Id","Ad");
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: Cars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id,  Arac arac, IFormFile? Resim1, IFormFile? Resim2, IFormFile? Resim3)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Resim1 is not null)
                    {
                        arac.Resim1 = await FileHelper.FileLoaderAsync(Resim1,"/Img/Cars/");
                    }
                    if (Resim2 is not null)
                    {
                        arac.Resim2 = await FileHelper.FileLoaderAsync(Resim2,"/Img/Cars/");
                    }
                    if (Resim3 is not null)
                    {
                        arac.Resim3 = await FileHelper.FileLoaderAsync(Resim3,"/Img/Cars/");
                    }
                    _service.Update(arac);
                    await _service.SaveAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("","Hata Olustu");
                }
                
            }
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsynch(),"Id","Ad");
            return View(arac);
        }

        // GET: Cars/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: Cars/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Arac arac)
        {
            try
            {
                _service.Delete(arac);
               await _service.SaveAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
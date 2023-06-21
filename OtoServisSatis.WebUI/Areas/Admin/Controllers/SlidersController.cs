using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtoServisSatis.Entities.Models;
using OtoServisSatis.Service.Abstract;
using OtoServisSatis.WebUI.Utils;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]
    public class SlidersController : Controller
    {

        private readonly IService<Slider> _service;

        public SlidersController(IService<Slider> service)
        {
            _service = service;
        }

        // GET: Sliders
        public async Task<ActionResult> Index()
        {
            return View(await _service.GetAllAsynch());
        }

        // GET: Sliders/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sliders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sliders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Slider collection, IFormFile? Resim)
        {
            try
            {
                collection.Resim = await FileHelper.FileLoaderAsync(Resim, "/Img/Slider/");
                await _service.AddAsync(collection);
                await _service.SaveAsync();
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Sliders/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var data = await _service.FindAsync(id);
            return View(data);
        }

        // POST: Sliders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Slider collection,IFormFile? Resim)
        {
            try
            {
                if (Resim is not null)
                    collection.Resim = await FileHelper.FileLoaderAsync(Resim, "/Img/Slider/");
                
                _service.Update(collection);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Sliders/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var data = await _service.FindAsync(id);
            return View(data);
        }

        // POST: Sliders/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Slider collection)
        {
            try
            {
                _service.Delete(collection);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OtoServisSatis.Entities.Models;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class BrandsController : Controller
    {
        private readonly IService<Marka> _service;

        public BrandsController(IService<Marka> service)
        {
            _service = service;
        }

        // GET: Brands
        public async Task<ActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsynch();
            return View(model);
        }

        // GET: Brands/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Brands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Brands/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Marka marka)
        {
            try
            {
                await _service.AddAsync(marka);
                await _service.SaveAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("","Hata Olustu");
            }
            return View();
        }

        // GET: Brands/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: Brands/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Marka marka)
        {
            try
            {
                 _service.Update(marka);
                await _service.SaveAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
               ModelState.AddModelError("","Hata Olustu");
            }
            return View();
        }

        // GET: Brands/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
           var model = await _service.FindAsync(id);
            
            return View(model);
        }

        // POST: Brands/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Marka marka)
        {
            try
            {
                _service.Delete(marka);
                _service.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
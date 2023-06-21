using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServisSatis.Entities.Models;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]
    public class SalesController : Controller
    {
        private readonly IService<Satis> _service;
        private readonly IService<Arac> _serviceArac;
        private readonly IService<Musteri> _serviceMusteri;

        public SalesController(IService<Satis> service, IService<Arac> serviceArac, IService<Musteri> serviceMusteri)
        {
            _service = service;
            _serviceArac = serviceArac;
            _serviceMusteri = serviceMusteri;
        }

        // GET: Sales
        public async Task<IActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsynch();
            return View(model);
        }

        // GET: Sales/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sales/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.AracId = new SelectList(await _serviceArac.GetAllAsynch(),"Id","Model");
            ViewBag.MusteriId = new SelectList(await _serviceMusteri.GetAllAsynch(), "Id", "Ad");
            return View();
        }

        // POST: Sales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Satis satis)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.AddAsync(satis);
                    await _service.SaveAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("","Hata Olustu");
                }
                
            }
            ViewBag.AracId = new SelectList(await _serviceArac.GetAllAsynch(),"Id","Model");
            ViewBag.MusteriId = new SelectList(await _serviceMusteri.GetAllAsynch(), "Id", "Ad");
            return View(satis);
        }
        

        // GET: Sales/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.AracId = new SelectList(await _serviceArac.GetAllAsynch(),"Id","Model");
            ViewBag.MusteriId = new SelectList(await _serviceMusteri.GetAllAsynch(), "Id", "Ad");
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: Sales/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Satis satis)
        {
            try
            {
                _service.Update(satis);
                await _service.SaveAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("","Hata Olustu");
            }
            ViewBag.AracId = new SelectList(await _serviceArac.GetAllAsynch(),"Id","Model");
            ViewBag.MusteriId = new SelectList(await _serviceMusteri.GetAllAsynch(), "Id", "Ad");
            return View(satis);
        }
       
        

        // GET: Sales/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: Sales/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Satis satis)
        {
            try
            {
                // TODO: Add delete logic here

                _service.Delete(satis);
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
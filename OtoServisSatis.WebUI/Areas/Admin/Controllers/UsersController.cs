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
    public class UsersController : Controller
    {
        private readonly IService<Kullanici> _service;

        private readonly IService<Rol> _serviceRol;
        // GET: Users
        
        public UsersController(IService<Kullanici> service, IService<Rol> serviceRol)
        {
            _service = service;
            _serviceRol = serviceRol;
        }

        public async Task<ActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsynch();
            return View(model);
        }
        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.RolId = new SelectList(await _serviceRol.GetAllAsynch(),"Id","Ad");
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                   await _service.AddAsync(kullanici);
                   await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("","Hata Olustu !!");
                }
            }
            ViewBag.RolId = new SelectList(await _serviceRol.GetAllAsynch(),"Id","Ad");
            return View(kullanici);
        }

        // GET: Users/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _service.FindAsync(id);
            ViewBag.RolId = new SelectList(await _serviceRol.GetAllAsynch(), "Id", "Ad");
            return View(model);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id,  Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                     _service.Update(kullanici);
                    await _service.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("","Hata Olustu !!");
                }
            }

            ViewBag.RolId = new SelectList(await _serviceRol.GetAllAsynch(), "Id", "Ad");
            return View(kullanici);
        }

        // GET: Users/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: Users/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Kullanici kullanici)
        {
            try
            {
                _service.Delete(kullanici);
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
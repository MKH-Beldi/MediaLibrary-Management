using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService clientService;
        private readonly ICategoryService categoryService;
        private readonly IMediaLibraryService mediaLibraryService;
        public ClientController(IClientService clientService, ICategoryService categoryService, IMediaLibraryService mediaLibraryService)
        {
            this.clientService = clientService;
            this.categoryService = categoryService;
            this.mediaLibraryService = mediaLibraryService;
        }
        // GET: ClientController
        public ActionResult Index()
        {
            return View(clientService.GetMany());
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            return View(clientService.GetById(id));
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            ViewBag.CategoryFK = new SelectList(categoryService.GetMany(), "Id", "Contribution");
            ViewBag.MediaLibraryFK = new SelectList(mediaLibraryService.GetMany(), "Key", "Name");
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client collection)
        {
            try
            {
                clientService.Add(collection);
                clientService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CategoryFK = new SelectList(categoryService.GetMany(), "Id", "Contribution");
            ViewBag.MediaLibraryFK = new SelectList(mediaLibraryService.GetMany(), "Key", "Name");
            return View(clientService.GetById(id));
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Client collection)
        {
            try
            {
                clientService.Update(collection);
                clientService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(clientService.GetById(id));
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Client collection)
        {
            try
            {
                clientService.Delete(collection);
                clientService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

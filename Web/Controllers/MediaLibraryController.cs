using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class MediaLibraryController : Controller
    {
        private readonly IMediaLibraryService mediaLibraryService;
        public MediaLibraryController(IMediaLibraryService mediaLibraryService)
        {
            this.mediaLibraryService = mediaLibraryService;
        }
        // GET: MediaLibraryController
        public ActionResult Index()
        {
            return View(mediaLibraryService.GetMany());
        }

        // GET: MediaLibraryController/Details/5
        public ActionResult Details(int id)
        {
            return View(mediaLibraryService.GetById(id));
        }

        // GET: MediaLibraryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MediaLibraryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MediaLibrary collection)
        {
            try
            {
                mediaLibraryService.Add(collection);
                mediaLibraryService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MediaLibraryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(mediaLibraryService.GetById(id));
        }

        // POST: MediaLibraryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MediaLibrary collection)
        {
            try
            {
                mediaLibraryService.Update(collection);
                mediaLibraryService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MediaLibraryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(mediaLibraryService.GetById(id));
        }

        // POST: MediaLibraryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MediaLibrary collection)
        {
            try
            {
                mediaLibraryService.Delete(collection);
                mediaLibraryService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

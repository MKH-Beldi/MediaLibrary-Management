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
    public class AudioController : Controller
    {
        private readonly IAudioService audioService;

        public AudioController(IAudioService audioService)
        {
            this.audioService = audioService;
        }
        // GET: Audio
        public ActionResult Index()
        {
            return View(audioService.GetMany());
        }

        // GET: Audio/Details/5
        public ActionResult Details(int id)
        {
            return View(audioService.GetById(id));
        }

        // GET: Audio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Audio/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Audio collection)
        {
            try
            {
                audioService.Add(collection);
                audioService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Audio/Edit/5
        public ActionResult Edit(int id)
        {
            return View(audioService.GetById(id));
        }

        // POST: Audio/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Audio collection)
        {
            try
            {
                audioService.Update(collection);
                audioService.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Audio/Delete/5
        public ActionResult Delete(int id)
        {
            return View(audioService.GetById(id));
        }

        // POST: Audio/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Audio collection)
        {
            try
            {
                audioService.Delete(collection);
                audioService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

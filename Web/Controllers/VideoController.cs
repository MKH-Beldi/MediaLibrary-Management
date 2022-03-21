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
    public class VideoController : Controller
    {
        private readonly IVideoService videoService;
        public VideoController(IVideoService videoService)
        {
            this.videoService = videoService;
        }
        // GET: VideoController
        public ActionResult Index()
        {
            return View(videoService.GetMany());
        }

        // GET: VideoController/Details/5
        public ActionResult Details(int id)
        {
            return View(videoService.GetById(id));
        }

        // GET: VideoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VideoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Video collection)
        {
            try
            {
                videoService.Add(collection);
                videoService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VideoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(videoService.GetById(id));
        }

        // POST: VideoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Video collection)
        {
            try
            {
                videoService.Update(collection);
                videoService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VideoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(videoService.GetById(id));
        }

        // POST: VideoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Video collection)
        {
            try
            {
                videoService.Delete(collection);
                videoService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

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
    public class BorrowController : Controller
    {
        private readonly IBorrowService borrowService;
        private readonly IClientService clientService;
        private readonly IDocumentService documentService;

        public BorrowController(IBorrowService borrowService, IClientService clientService, IDocumentService documentService)
        {
            this.borrowService = borrowService;
            this.clientService = clientService;
            this.documentService = documentService;
        }

        // GET: BorrowController
        public ActionResult Index()
        {
            return View(borrowService.GetMany());
        }

        // GET: BorrowController/Details/5
        public ActionResult Details(int id)
        {
            return View(borrowService.GetById(id));
        }

        // GET: BorrowController/Create
        [Route("Borrow/{idClient}/{idDocument}")]
        public ActionResult Create(string idClient, string idDocument)
        {
            if(string.IsNullOrEmpty(idClient) && string.IsNullOrEmpty(idDocument))
            {
                ViewBag.ClientFK = new SelectList(clientService.GetMany().ToList(), "ClientId", "FirstName");
                ViewBag.DocumentFK = new SelectList(documentService.GetMany().ToList(), "Key", "Title");
            }
            else
            {
                ViewBag.ClientFK = new SelectList(clientService.GetMany(c => c.ClientId == Int32.Parse(idClient)).ToList(), "ClientId", "FirstName");
                ViewBag.DocumentFK = new SelectList(documentService.GetMany(d => d.Key == Int32.Parse(idDocument)).ToList(), "Key", "Title");
            }
            
            return View();
        }

        // POST: BorrowController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Borrow collection)
        {
            try
            {
                borrowService.Add(collection);
                borrowService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BorrowController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(borrowService.GetById(id));
        }

        // POST: BorrowController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Borrow collection)
        {
            try
            {
                borrowService.Update(collection);
                borrowService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BorrowController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(borrowService.GetById(id));
        }

        // POST: BorrowController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Borrow collection)
        {
            try
            {
                borrowService.Delete(collection);
                borrowService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

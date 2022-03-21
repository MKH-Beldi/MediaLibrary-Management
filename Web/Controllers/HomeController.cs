using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDocumentService documentService;
        private readonly IBorrowService borrowService;
        private readonly IClientService clientService;
        public HomeController(ILogger<HomeController> logger, IDocumentService documentService, IBorrowService borrowService, IClientService clientService)
        {
            _logger = logger;
            this.documentService = documentService;
            this.borrowService = borrowService;
            this.clientService = clientService;
        }

        public IActionResult Index(string searchTitle)
        {
            Client client = clientService.GetById(2);
            ViewBag.ClientId = client.ClientId;
            ViewBag.ClientName = client.FirstName + " " + client.LastName;
            if (string.IsNullOrEmpty(searchTitle))
            {
                IList<Document> documents = documentService.GetMany(d => d.MediaLibrary.Key == client.MediaLibraryFK).ToList();
                foreach (var item in documents)
                {
                    item.NbrBorrows = borrowService.NbrBorrowsByDocument(item);
                    if (borrowService.Borrowable(item))
                        item.Borrowable = true;
                    if (borrowService.Borrowed(item))
                        item.Borrowed = true;
                }
                return View(documents);
            }
            else
            {
                IList<Document> documents = documentService.GetMany(d => d.Title.Contains(searchTitle)).Where(d => d.MediaLibrary.Key == client.MediaLibraryFK).ToList();
                foreach (var item in documents)
                {
                    item.NbrBorrows = borrowService.NbrBorrowsByDocument(item);
                    if (borrowService.Borrowable(item))
                        item.Borrowable = true;
                    if (borrowService.Borrowed(item))
                        item.Borrowed = true;
                }
                return View(documents);
            }
            

           
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

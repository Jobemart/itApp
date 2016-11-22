using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using itApp.Models;
using itApp.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace itApp.Controllers
{
    public class HomeController : Controller
    {
        DataController data = new DataController();

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CaseQuestionnaire()
        {
            CaseViewModel cvm = new CaseViewModel();

            return View(cvm);
        }

        [HttpPost]
        public IActionResult CaseQuestionnaire(CaseViewModel cvm)
        {
            Case newCase = new Case();
            newCase.Title = cvm.Title;

            return View("ComprobationCase",cvm);
        }

        public IActionResult ComprobationCase(Case newCase)
        {
            data.DataBaseConnection(); 
            return View(newCase);
        }
    }
}

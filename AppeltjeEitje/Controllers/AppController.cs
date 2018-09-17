using AppeltjeEitje.Data;
using AppeltjeEitje.Data.Entities;
using AppeltjeEitje.Services;
using AppeltjeEitje.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppeltjeEitje.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailservice;
        private readonly AppelEiContext _context;

        public AppController(IMailService mailservice, AppelEiContext context)
        {
            _mailservice = mailservice;
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.Personen.ToList();
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contactpagina";
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                _mailservice.SendMessage("dennis.zuidam@outlook.com", model.Bericht);
                ViewBag.UserMessage = "Mail verzonden";
                ModelState.Clear();
            }
            else
            {

            }


            return View();
        }

        [HttpGet("overons")]
        public IActionResult About()
        {
            ViewBag.Title = "Over ons";
            return View();
        }

        public IActionResult Groepen()
        {
            var results = from g in _context.Groepen
                          orderby g.Naam
                          select g;

            return View(results.ToList());
        }



        //Inschrijvingen
        public IActionResult Inschrijvingen()
        {
            var result = from p in _context.Personen
                         orderby p.Achternaam
                         select p;

            return View(result.ToList());
        }

        //[HttpPost("inschrijvingen")]
        //public IActionResult Inschrijvingen(Persoon persoon)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(persoon);
        //        ModelState.Clear();
        //    }
        //    else
        //    {

        //    }
        //    return View();
        //}
    }
}

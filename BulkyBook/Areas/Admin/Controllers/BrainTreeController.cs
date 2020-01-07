using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrainTreeController : Controller
    {
        public IBrainTreeGate _brain { get; set; }

        public BrainTreeController(IBrainTreeGate brain)
        {
            _brain = brain;
        }

        public IActionResult Index()
        {
            var gateway = _brain.GetGateway();
            var clientToken = gateway.ClientToken.Generate();
            ViewBag.ClientToken = clientToken;
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Controllers
{
    public class AngularController : Controller
    {
        // GET: Angular
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult ClassifiedsPartial()
        {
            return View();
        }

        public ActionResult ClassifiedCard()
        {
            return View();
        }
    }
}
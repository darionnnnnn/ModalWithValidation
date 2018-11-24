using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModalWithValidation.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            NorthwindEntities nwEntities = new NorthwindEntities();

            var data = nwEntities.Categories.Take(20);

            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Categories category)
        {
            NorthwindEntities nwEntities = new NorthwindEntities();

            if (category != null && ModelState.IsValid)
            {
                nwEntities.Categories.Add(category);

                nwEntities.SaveChanges();

                return RedirectToAction("index");
            }
            else
            {
                return View(category);
            }
        }
    }
}
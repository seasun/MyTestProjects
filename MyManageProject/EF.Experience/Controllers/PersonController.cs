using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EF.Experience.Models;

namespace EF.Experience.Controllers
{
    public class PersonController : Controller
    {
        //
        // GET: /Index/

        public ActionResult Index()
        {
            School schoolDb = new School();
            return View(schoolDb.Persons.ToList());
        }

        public ActionResult Add()
        {
            School schoolDb = new School();
            schoolDb.Persons.Add(new Person { Name = "seasun", Age = 25 });
            schoolDb.Persons.Add(new Person { Name = "小蔣", Age = 26, Number = 1 });
            schoolDb.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

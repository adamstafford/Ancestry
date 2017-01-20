using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ancestry.Models;
using Ancestry.Helpers;
using NHibernate;
using System.Diagnostics;

namespace Ancestry.Controllers
{
    [Internationalization]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return View(session.CreateCriteria<Review>().List<Review>().OrderBy(r => r.Name));
        }

        public ActionResult AverageAge()
        {
            ISession session = NHibernateHelper.OpenSession();

            List<Review> list = session.CreateCriteria<Review>().List<Review>().ToList();
            int? totalAge = 0;

            foreach(Review r in list)
            {
                if(r.Age != null)
                {
                    totalAge += r.Age;
                }
            }

            ViewBag.AverageAge = totalAge / list.Count;
            return View();
        }

        public ActionResult AverageScales()
        {
            ISession session = NHibernateHelper.OpenSession();

            List<Review> list = session.CreateCriteria<Review>().List<Review>().ToList();
            int Find = 0;
            int Products = 0;
            int Checkout = 0;
            int Experience = 0;

            //Average per person?
            foreach (Review r in list)
            {
                Find += r.AbilityToFind;
                Products += r.RangeOfProducts;
                Checkout += r.EasyCheckout;
                Experience += r.OverallExperience;
            }

            ViewBag.Find = Find / list.Count;
            ViewBag.Products = Products / list.Count;
            ViewBag.Checkout = Checkout / list.Count;
            ViewBag.Experience = Experience / list.Count;
            return View();
        }

        public ActionResult GenderDist()
        {
            ISession session = NHibernateHelper.OpenSession();

            List<Review> list = session.CreateCriteria<Review>().List<Review>().ToList();
            float totalMales = 0;
            float totalFemales = 0;

            foreach (Review r in list)
            {
                if (r.Gender == "Male")
                {
                    totalMales++;
                }
                else if(r.Gender == "Female")
                {
                    totalFemales++;
                }
            }

            ViewBag.Males = (totalMales / list.Count) * 100;
            ViewBag.Females = (totalFemales / list.Count) * 100;
            return View();
        }

        public ActionResult ThankYou()
        {

            return View();
        }

        public ActionResult Device()
        {
            ISession session = NHibernateHelper.OpenSession();

            List<Review> list = session.CreateCriteria<Review>().List<Review>().ToList();
            float Mobile = 0;
            float Tablet = 0;
            float Desktop = 0;

            foreach (Review r in list)
            {
                if (r.Device == "Mobile")
                {
                    Mobile++;
                }
                else if (r.Device == "Tablet")
                {
                    Tablet++;
                }
                else if (r.Device == "Desktop")
                {
                    Desktop++;
                }
            }

            ViewBag.Mobile = (Mobile / list.Count) * 100;
            ViewBag.Tablet = (Tablet / list.Count) * 100;
            ViewBag.Desktop = (Desktop / list.Count) * 100;
            return View();
        }

        public ActionResult AngularSurvey()
        {
            return View();
        }
    }
}
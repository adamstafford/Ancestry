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
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            Review review = new Review();
            review.Name = formCollection["Name"];
            review.Email = formCollection["Email"];
            review.Age = Int32.Parse(formCollection["Age"]); //need try catch
            review.Gender = formCollection["Gender"];
            review.AbilityToFind = Int32.Parse(formCollection["AbilityToFind"]);
            review.RangeOfProducts = Int32.Parse(formCollection["RangeOfProducts"]);
            review.EasyCheckout = Int32.Parse(formCollection["EasyCheckout"]);
            review.OverallExperience = Int32.Parse(formCollection["OverallExperience"]);
            review.MostLiked = formCollection["MostLiked"];
            review.MostDisliked = formCollection["MostDisliked"];
            review.MostLikeToSee = formCollection["MostLikeToSee"];
            review.TimeDate = DateTime.Now;
            review.IpAddress = GetIPAddress();
            review.Browser = GetBrowser();
            review.Device = GetDevice();

            using (ISession session = NHibernateHelper.OpenSession())
            {
                using(ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(review);
                    transaction.Commit();
                }
            }

            return RedirectToAction("ThankYou");
        }

        public ActionResult List()
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return View(session.CreateCriteria<Review>().List<Review>());

        }

        public ActionResult AverageAge()
        {
            ISession session = NHibernateHelper.OpenSession();

            List<Review> list = session.CreateCriteria<Review>().List<Review>().ToList();
            int? totalAge = 0;

            foreach(Review r in list)
            {
                totalAge += r.Age;
            }

            ViewBag.AverageAge = totalAge / list.Count;

            return View();
        }

        public ActionResult AverageScales()
        {
            ISession session = NHibernateHelper.OpenSession();

            List<Review> list = session.CreateCriteria<Review>().List<Review>().ToList();
            int totalScales = 0;

            foreach (Review r in list)
            {
                totalScales += r.AbilityToFind;
                totalScales += r.RangeOfProducts;
                totalScales += r.EasyCheckout;
                totalScales += r.OverallExperience;
            }

            ViewBag.AverageScales = totalScales / (list.Count * 4);

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
                if(r.Gender == "Female")
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

        protected string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }

        protected string GetBrowser()
        {
            System.Web.HttpBrowserCapabilitiesBase browser = Request.Browser;
            return (browser.Browser);
        }

        protected string GetDevice()
        {
            System.Web.HttpBrowserCapabilitiesBase browser = Request.Browser;

            if (browser.IsMobileDevice)
            {
                return browser.ScreenPixelsWidth < 720 ? "Mob" : "Tablet";
            }
            else
            {
                return "Desktop";
            }
        }
    }
}
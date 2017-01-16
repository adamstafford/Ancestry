using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ancestry.Models;

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
            review.Age = Int32.Parse(formCollection["Age"]);
            review.AbilityToFind = Int32.Parse(formCollection["AbilityToFind"]);
            review.RangeOfProducts = Int32.Parse(formCollection["RangeOfProducts"]);
            review.EasyCheckout = Int32.Parse(formCollection["EasyCheckout"]);
            review.OverallExperience = Int32.Parse(formCollection["OverallExperience"]);
            review.MostLiked = formCollection["MostLiked"];
            review.MostDisliked = formCollection["MostDisliked"];
            review.MostLikeToSee = formCollection["MostLikeToSee"];

            ReviewContext reviewContext = new ReviewContext();
            reviewContext.AddReview(review);

            return RedirectToAction("Index");
        }

        public ActionResult List()
        {
            ReviewContext reviewContext = new ReviewContext();

            return View(reviewContext.review.ToList());
        }

        public ActionResult AverageAge()
        {
            ReviewContext reviewContext = new ReviewContext();

            List<Review> list = reviewContext.review.ToList();
            int TotalAge = 0;

            foreach(Review r in list)
            {
                TotalAge += r.Age;
            }

            ViewBag.AverageAge = TotalAge / list.Count;

            return View();
        }

        public ActionResult AverageScales()
        {
            ReviewContext reviewContext = new ReviewContext();

            List<Review> list = reviewContext.review.ToList();
            int TotalScales = 0;

            foreach (Review r in list)
            {
                TotalScales += r.AbilityToFind;
                TotalScales += r.RangeOfProducts;
                TotalScales += r.EasyCheckout;
                TotalScales += r.OverallExperience;
            }

            ViewBag.AverageScales = TotalScales / (list.Count * 4);

            return View();
        }

        public ActionResult GenderDist()
        {
            return View();
        }
    }
}
﻿using System;
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
            review.Age = Int32.Parse(formCollection["Age"]); //need try catch
            review.Gender = formCollection["Gender"];
            review.AbilityToFind = Int32.Parse(formCollection["AbilityToFind"]);
            review.RangeOfProducts = Int32.Parse(formCollection["RangeOfProducts"]);
            review.EasyCheckout = Int32.Parse(formCollection["EasyCheckout"]);
            review.OverallExperience = Int32.Parse(formCollection["OverallExperience"]);
            review.MostLiked = formCollection["MostLiked"];
            review.MostDisliked = formCollection["MostDisliked"];
            review.MostLikeToSee = formCollection["MostLikeToSee"];

            ReviewContext reviewContext = new ReviewContext();
            reviewContext.AddReview(review);

            return RedirectToAction("ThankYou");
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
            ReviewContext reviewContext = new ReviewContext();

            List<Review> list = reviewContext.review.ToList();
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
            ReviewContext reviewContext = new ReviewContext();

            List<Review> list = reviewContext.review.ToList();
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
    }
}
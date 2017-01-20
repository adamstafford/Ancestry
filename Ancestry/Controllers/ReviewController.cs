using Ancestry.Helpers;
using Ancestry.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Ancestry.Controllers
{
    public class ReviewController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post(Review review)
        {
            review.TimeDate = DateTime.Now;
            review.IpAddress = GetIPAddress();
            review.Browser = GetBrowser();
            review.Device = GetDevice();

            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(review);
                    transaction.Commit();
                }
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
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
            HttpBrowserCapabilities context = HttpContext.Current.Request.Browser;
            return (context.Browser);
        }

        protected string GetDevice()
        {
            string ua = HttpContext.Current.Request.Headers["User-Agent"];

            if (HttpContext.Current.Request.Browser.IsMobileDevice && !MobileHelper.IsTablet(ua))
            {
                return "Mobile";
            }
            else if (MobileHelper.IsTablet(ua))
            {
                return "Tablet";
            }
            else
            {
                return "Desktop";
            }
        }  
    }
}
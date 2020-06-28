using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppYte.Models;

namespace WebAppYte.Controllers
{
    public class LichKhamController : Controller
    {
        WebAppYteEntities db = new WebAppYteEntities();
        // GET: LichKham
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetEvents()
        {
            using(WebAppYteEntities db= new WebAppYteEntities())
            {
                var events = db.LichKhams.ToList();


                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            
            
        }
        private static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }


    }
}
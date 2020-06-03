using System.Net;
using System.Web.Mvc;
using ZaghiniAdmin.Models;
using System.Web;
using System;

namespace ZaghiniAdmin.Controllers
{
    public class HomeController : Controller
    {
        private DB_A37A16_zaghiniEntities db = new DB_A37A16_zaghiniEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Profile(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            users users = db.users.Find(id);

            if (users == null)
                return HttpNotFound();

            return View(users);
        }

        [HttpPost]
        public void UploadFile()
        {
            try
            {
                HttpPostedFileBase File = Request.Files[0];

                //salvar
                var dir = Server.MapPath("../Images/Users/");
                var imageName = "image" + Session["userId"] + ".jpg";
                Session["lastImageName"] = imageName;
                File.SaveAs(dir + imageName);
            }
            catch (Exception e)
            {
                var err = e.InnerException;
            }
        }
    }
}
using System.Linq;
using System.Web.Mvc;
using ZaghiniAdmin.Code;
using ZaghiniAdmin.Models;

namespace ZaghiniAdmin.Controllers
{
    public class LoginController : Controller
    {
        private DB_A37A16_zaghiniEntities db = new DB_A37A16_zaghiniEntities();

        // GET: Login
        public ActionResult Index()
        {
            Session["logged"] = null;
            Session["userId"] = null;
            Session["userName"] = null;
            Session["userFirstName"] = null;
            Session["userType"] = null;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(users param)
        {
            string typedPassword = param.password;
            string dataBasePassword = (from u in db.users where u.login == param.login select u.password).FirstOrDefault();

            bool isValid = SystemFunctions.VerifyHash(typedPassword, dataBasePassword);

            if (isValid)
            {
                Session["logged"] = "HomeSweetHome";
                var userData = (from u in db.users
                                join t in db.usertype on u.idusertype equals t.id
                                where u.login == param.login select new {
                                    u.id,
                                    u.name,
                                    t.description
                                }).FirstOrDefault();

                int userId = userData.id;
                string userName = userData.name;
                string userFirstName = userData.name.Split(' ').FirstOrDefault();

                Session["userId"] = userId;
                Session["userName"] = userName;
                Session["userFirstName"] = userFirstName;
                Session["userType"] = userData.description;

                ViewBag.Error = null;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Session["logged"] = null;
                ViewBag.Error = "Invalid data Input, try another Login or Password!";
                return View();
            }
        }


    }
}
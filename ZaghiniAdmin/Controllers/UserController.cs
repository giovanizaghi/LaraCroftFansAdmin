using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ZaghiniAdmin.Code;
using ZaghiniAdmin.Models;

namespace ZaghiniAdmin.Controllers
{
    public class UserController : Controller
    {
        private DB_A37A16_zaghiniEntities db = new DB_A37A16_zaghiniEntities();
        // GET: User
        public ActionResult Index()
        {
            var users = db.users.Include(u => u.usertype);
            return View(users.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            ViewBag.idusertype = new SelectList(db.usertype, "id", "description");
            return View();
        }

        // POST: User/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,login,password,idusertype")] users users)
        {
            if (ModelState.IsValid)
            {
                users.password = users.password.Encrypt();

                db.users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idusertype = new SelectList(db.usertype, "id", "description", users.idusertype);
            return View(users);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            ViewBag.idusertype = new SelectList(db.usertype, "id", "description", users.idusertype);
            return View(users);
        }

        // POST: User/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,login,password,idusertype")] users users)
        {
            if (ModelState.IsValid)
            {
                users.password = users.password.Encrypt();

                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idusertype = new SelectList(db.usertype, "id", "description", users.idusertype);
            return View(users);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            users users = db.users.Find(id);
            db.users.Remove(users);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ZaghiniAdmin.Models;

namespace ZaghiniAdmin.Controllers
{
    public class TagController : Controller
    {
        private DB_A37A16_zaghiniEntities db = new DB_A37A16_zaghiniEntities();

        // GET: Tag
        public ActionResult Index()
        {
            return View(db.tags.ToList());
        }

        // GET: Tag/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tags tags = db.tags.Find(id);
            if (tags == null)
            {
                return HttpNotFound();
            }
            return View(tags);
        }

        // GET: Tag/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tag/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,description")] tags tags)
        {
            if (ModelState.IsValid)
            {
                db.tags.Add(tags);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tags);
        }

        // GET: Tag/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tags tags = db.tags.Find(id);
            if (tags == null)
            {
                return HttpNotFound();
            }
            return View(tags);
        }

        // POST: Tag/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,description")] tags tags)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tags).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tags);
        }

        // GET: Tag/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tags tags = db.tags.Find(id);
            if (tags == null)
            {
                return HttpNotFound();
            }
            return View(tags);
        }

        // POST: Tag/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tags tags = db.tags.Find(id);
            db.tags.Remove(tags);
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

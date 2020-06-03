using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using ZaghiniAdmin.Models;

namespace ZaghiniAdmin.Controllers
{
    public class sectionitemsController : Controller
    {
        private DB_A37A16_zaghiniEntities db = new DB_A37A16_zaghiniEntities();

       
        // GET: sectionitems/Create
        public ActionResult Create(int? idSection)
        {
            ViewBag.idsection = idSection;
            return View();
        }

        // POST: sectionitems/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "id,title,content,active,onlyregistercanread,idsection,image")] sectionitem sectionitem, string active, string onlyregistercanread)
        {

            sectionitem.active = active == "on" ? false : true;
            sectionitem.onlyregistercanread = onlyregistercanread == "on" ? true : false;
            sectionitem.image = Session["lastImageName"] != null ? Session["lastImageName"].ToString() : null;
            db.sectionitem.Add(sectionitem);
            db.SaveChanges();


            ViewBag.idsection = new SelectList(db.section, "id", "description", sectionitem.idsection);
            return RedirectToAction("Edit", "sections", new { id = sectionitem.idsection });
        }

        // GET: sectionitems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sectionitem sectionitem = db.sectionitem.Find(id);
            if (sectionitem == null)
            {
                return HttpNotFound();
            }
            ViewBag.idsection = new SelectList(db.section, "id", "description", sectionitem.idsection);
            return View(sectionitem);
        }

        // POST: sectionitems/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "id,title,content,active,onlyregistercanread,idsection,image")] sectionitem sectionitem, string active, string onlyregistercanread)
        {

            sectionitem.active = active == "on" ? false : true;
            sectionitem.onlyregistercanread = onlyregistercanread == "on" ? true : false;
            sectionitem.image = Session["lastImageName"] != null ? Session["lastImageName"].ToString() : null;

            db.Entry(sectionitem).State = EntityState.Modified;
            db.SaveChanges();

            ViewBag.idsection = new SelectList(db.section, "id", "description", sectionitem.idsection);

            ViewBag.register = sectionitem.onlyregistercanread ? "checked" : "";
            ViewBag.draft = !sectionitem.active ? "checked" : "";
            return RedirectToAction("Edit","sections",new { id = sectionitem.idsection });

        }

        // GET: sectionitems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sectionitem sectionitem = db.sectionitem.Find(id);
            if (sectionitem == null)
            {
                return HttpNotFound();
            }
            return View(sectionitem);
        }

        // POST: sectionitems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sectionitem sectionitem = db.sectionitem.Find(id);
            db.sectionitem.Remove(sectionitem);
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

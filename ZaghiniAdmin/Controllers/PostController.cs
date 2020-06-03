using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZaghiniAdmin.Models;

namespace ZaghiniAdmin.Controllers
{
    public class PostController : Controller
    {
        private DB_A37A16_zaghiniEntities db = new DB_A37A16_zaghiniEntities();

        // GET: Post
        public ActionResult Index()
        {
            var posts = db.posts.Include(p => p.tags).Include(p => p.users).OrderByDescending(x => x.id);
            return View(posts.ToList());
        }

        // GET: Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            posts posts = db.posts.Find(id);
            if (posts == null)
            {
                return HttpNotFound();
            }
            return View(posts);
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            ViewBag.idtag = new SelectList(db.tags, "id", "description");
            ViewBag.iduser = new SelectList(db.users, "id", "name");
            return View();
        }

        // POST: Post/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "id,title,content,image,postdate,active,onlyregistercanread,iduser,idtag")] posts posts, string active, string onlyregistercanread)
        {

            posts.active = active == "on" ? false : true;
            posts.onlyregistercanread = onlyregistercanread == "on" ? true : false;
            posts.image = Session["lastImageName"] != null ? Session["lastImageName"].ToString() : null;
            db.posts.Add(posts);
            db.SaveChanges();
            ViewBag.idtag = new SelectList(db.tags, "id", "description", posts.idtag);
            ViewBag.iduser = new SelectList(db.users, "id", "name", posts.iduser);


            return RedirectToAction("Index");
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            posts posts = db.posts.Find(id);
            if (posts == null)
            {
                return HttpNotFound();
            }
                        
            ViewBag.register = posts.onlyregistercanread ? "checked" : "";
            ViewBag.draft = !posts.active ? "checked" : "";

            ViewBag.idtag = new SelectList(db.tags, "id", "description", posts.idtag);
            ViewBag.iduser = new SelectList(db.users, "id", "name", posts.iduser);
            return View(posts);
        }

        // POST: Post/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "id,title,content,image,postdate,active,onlyregistercanread,iduser,idtag")] posts posts, string active, string onlyregistercanread)
        {

            posts.active = active == "on" ? false : true;
            posts.onlyregistercanread = onlyregistercanread == "on" ? true : false;
            posts.image = Session["lastImageName"] != null ? Session["lastImageName"].ToString() : null;
            db.Entry(posts).State = EntityState.Modified;
            db.SaveChanges();


            ViewBag.idtag = new SelectList(db.tags, "id", "description", posts.idtag);
            ViewBag.iduser = new SelectList(db.users, "id", "name", posts.iduser);

            return RedirectToAction("Index");
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            posts posts = db.posts.Find(id);
            if (posts == null)
            {
                return HttpNotFound();
            }
            return View(posts);
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            posts posts = db.posts.Find(id);
            db.posts.Remove(posts);
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
        [HttpPost]
        public string UploadFile()
        {
            try
            {
                HttpPostedFileBase File = Request.Files[0];

                //salvar
                var dir = Server.MapPath("../Images/Posts/");
                var imageName = "image" + DateTime.Today.Year + DateTime.Today.Month + DateTime.Today.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Millisecond + ".jpg";
                Session["lastImageName"] = imageName;
                File.SaveAs(dir + imageName);

                return imageName;
            }
            catch (Exception e)
            {
                return e.InnerException.ToString();
            }
        }
    }
}

using System.Web.Mvc;
using OJ.Models;
using OJ.OJService;

namespace OJ.Controllers
{
    public class UserController : Controller
    {
        //private ModelContainer db = new ModelContainer();
        private UserModel model;

        public UserController()
        {
            model = new UserModel();
        }
        //
        // GET: /User/

        //public ViewResult Index()
        //{
        //    return View(this.model.UserList);
        //}

        //
        // GET: /User/Details/5

        public ViewResult Details(long id)
        {
            UserDO user = this.model.GetUser(id);
            return View(user);
        }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            UserDO DO = this.model.GetUser(username);
            if (DO != null)
            {
                if (password == DO.Password)
                {
                    Session["User"] = DO;
                    return RedirectToAction("ProblemList", "Problem");
                }
            }
            return View();
        }

        public ViewResult Regist()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Regist(UserDO user)
        {
            if (this.model.AddUser(user))
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Login");
        }


        //[HttpPost]
        //public ViewResult Regist(UserDO user)
        //{
        //    return View();
        //}

        ////
        //// GET: /User/Create

        //public ActionResult Create()
        //{
        //    ViewBag.id_language = new SelectList(db.LanguageSet, "id", "name");
        //    return View();
        //}

        ////
        //// POST: /User/Create

        //[HttpPost]
        //public ActionResult Create(User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.UserSet.AddObject(user);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.id_language = new SelectList(db.LanguageSet, "id", "name", user.id_language);
        //    return View(user);
        //}

        ////
        //// GET: /User/Edit/5

        //public ActionResult Edit(long id)
        //{
        //    User user = db.UserSet.Single(u => u.id == id);
        //    ViewBag.id_language = new SelectList(db.LanguageSet, "id", "name", user.id_language);
        //    return View(user);
        //}

        ////
        //// POST: /User/Edit/5

        //[HttpPost]
        //public ActionResult Edit(User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.UserSet.Attach(user);
        //        db.ObjectStateManager.ChangeObjectState(user, EntityState.Modified);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.id_language = new SelectList(db.LanguageSet, "id", "name", user.id_language);
        //    return View(user);
        //}

        ////
        //// GET: /User/Delete/5

        //public ActionResult Delete(long id)
        //{
        //    User user = db.UserSet.Single(u => u.id == id);
        //    return View(user);
        //}

        ////
        //// POST: /User/Delete/5

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(long id)
        //{
        //    User user = db.UserSet.Single(u => u.id == id);
        //    db.UserSet.DeleteObject(user);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}
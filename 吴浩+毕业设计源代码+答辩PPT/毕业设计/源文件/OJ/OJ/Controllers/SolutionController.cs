using System;
using System.Web.Mvc;
using OJ.Models;
using OJ.OJService;

namespace OJ.Controllers
{
    public class SolutionController : Controller
    {
        //private ModelContainer db = new ModelContainer();

        private SolutionModel model;

        public SolutionController()
        {
            model = new SolutionModel();
        }

        public ViewResult SolutionList(string id)
        {
            string[] actionParams = id == null ? new string[0] : id.Split('/');
            SolutionPageList solutionPageList = model.GetSolutionPageList(100,
                actionParams.Length >= 1 ? Convert.ToInt32(actionParams[0]) : 1,
                actionParams.Length >= 2 ? actionParams[1] : string.Empty);
            return View(solutionPageList);
        }


        ////
        //// GET: /Solution/

        //public ViewResult Index()
        //{
        //    var solution = db.Solution.Include("language");
        //    return View(solution.ToList());
        //}

        ////
        //// GET: /Solution/Details/5

        //public ViewResult Details(long id)
        //{
        //    SolutionDO solutiondo = db.Solution.Single(s => s.id == id);
        //    return View(solutiondo);
        //}

        ////
        //// GET: /Solution/Create

        //public ActionResult Create()
        //{
        //    ViewBag.id_language = new SelectList(db.Language, "id", "name");
        //    return View();
        //}

        ////
        //// POST: /Solution/Create

        //[HttpPost]
        //public ActionResult Create(SolutionDO solutiondo)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Solution.AddObject(solutiondo);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.id_language = new SelectList(db.Language, "id", "name", solutiondo.id_language);
        //    return View(solutiondo);
        //}

        ////
        //// GET: /Solution/Edit/5

        //public ActionResult Edit(long id)
        //{
        //    SolutionDO solutiondo = db.Solution.Single(s => s.id == id);
        //    ViewBag.id_language = new SelectList(db.Language, "id", "name", solutiondo.id_language);
        //    return View(solutiondo);
        //}

        ////
        //// POST: /Solution/Edit/5

        //[HttpPost]
        //public ActionResult Edit(SolutionDO solutiondo)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Solution.Attach(solutiondo);
        //        db.ObjectStateManager.ChangeObjectState(solutiondo, EntityState.Modified);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.id_language = new SelectList(db.Language, "id", "name", solutiondo.id_language);
        //    return View(solutiondo);
        //}

        ////
        //// GET: /Solution/Delete/5

        //public ActionResult Delete(long id)
        //{
        //    SolutionDO solutiondo = db.Solution.Single(s => s.id == id);
        //    return View(solutiondo);
        //}

        ////
        //// POST: /Solution/Delete/5

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(long id)
        //{
        //    SolutionDO solutiondo = db.Solution.Single(s => s.id == id);
        //    db.Solution.DeleteObject(solutiondo);
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
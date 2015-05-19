using Stromblom.Portfolio.Database;
using Stromblom.Portfolio.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Stromblom.Portfolio.Controllers
{
    public class ProjectController : Controller
    {
        private readonly PortfolioDBContext _dbContext = new PortfolioDBContext();
        //
        // GET: /Project/
        public ActionResult Index()
        {
            var projects = _dbContext.Projects.ToList();

            return View(projects);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var project = _dbContext.Projects.SingleOrDefault(x => x.ID == id);

            if (project == null)
                return HttpNotFound();

            return View(project);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View("CreateOrEdit");
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Project model, HttpPostedFileBase imageFile)
        {
            //if (!ModelState.IsValid)
            //    return View("CreateOrEdit");

            var path = String.Empty;
            if (imageFile != null || imageFile.ContentLength > 0)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var filePath = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                
                try
                {
                    imageFile.SaveAs(filePath);
                    path = String.Format("/Content/Images/{0}", fileName);
                }
                catch (Exception e)
                { }

            }

            model.Image = path;
            _dbContext.Projects.Add(model);
            _dbContext.SaveChanges();

            ViewBag.Message = "Project added!";

            return View("CreateOrEdit");
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            ViewBag.Edit = true;

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var project = _dbContext.Projects.SingleOrDefault(x => x.ID == id);

            project = project ?? new Project();
            return View("CreateOrEdit", project);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(Project model)
        {
            ViewBag.Edit = true;

            if (!ModelState.IsValid)
                return View("CreateOrEdit");

            if (model.ID == 0)
            {
                ModelState.AddModelError("ID", "ID can't be 0. Maybe you want to create instead?");
                return View("CreateOrEdit");
            }

            _dbContext.Entry<Project>(model).State = EntityState.Modified;
            _dbContext.SaveChanges();

            ViewBag.Message = "Project has been saved.";

            return View("CreateOrEdit");
        }
	}
}
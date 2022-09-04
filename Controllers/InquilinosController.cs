using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using inmoCabreraNet.Models;

namespace inmoCabreraNet.Controllers {
    public class InquilinosController : Controller {
        RepoInquilino repoInqui = new RepoInquilino();
        // GET: Inquilinos
        public ActionResult Index() {

            IList<Inquilino> lista = repoInqui.All();
            return View(lista);
        }

        // GET: Inquilinos/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: Inquilinos/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Inquilinos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection) {
            try {
                // TODO: Add insert logic here
                repoInqui.Put(  new Inquilino {
                    inq_dni = collection["inq_dni"],
                    inq_nombre = collection["inq_nombre"],
                    inq_fechanac = DateTime.Parse(collection["inq_fechanac"]),
                    inq_domicilioTrabajo = collection["inq_domicilioTrabajo"],
                    inq_telef = collection["inq_telef"],
                    inq_email = collection["inq_email"]}
                    );
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        // GET: Inquilinos/Edit/5
        public ActionResult Edit(int id) {
             try {
                // TODO: Add update logic here

                 var i = repoInqui.FindByPrimaryKey(id);
                if (i.inq_id > 0)
                { TempData["msg"] = "Se encontró.";
                    return View(i);
                }
                else
                {
                    TempData["msg"] = "No se encontró Inquilino. Intente nuevamente.";
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: Inquilinos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection) {
              try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Inquilinos/Delete/5
        public ActionResult Delete(int id) {
             try
                {
                   var inq = repoInqui.FindByPrimaryKey(id);
                if (inq.inq_id > 0)
                {
                    return View(inq);
                }
                else
                {
                    TempData["msg"] = "No se encontró Inquilino. Intente nuevamente.";
                    return RedirectToAction(nameof(Index));
                }
                }
                catch (Exception)
                {
                    throw;
                }
        }

        // POST: Inquilinos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) {
            try {
               var res = repoInqui.Delete(id);
                if (res > 0)
                {
                    TempData["msg"] = "Inquilino borrado.";
                    return RedirectToAction(nameof(Index));
                }
                else if (res == 0)
                {
                    TempData["msg"] = "No se pudo borrar Inquilino. Intente nuevamente.";
                    return RedirectToAction(nameof(Delete), new { id = id });
                }
               
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }
    }
}
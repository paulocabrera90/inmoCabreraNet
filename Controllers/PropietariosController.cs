using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using inmoCabreraNet.Models;

namespace inmoCabreraNet.Controllers
{
    public class PropietariosController : Controller
    {
        RepoPropietario repo = new RepoPropietario();
        // GET: Propietarios
        public ActionResult Index()
        {
            IList<Propietario> lista = repo.All();
            return View(lista);
        }

        // GET: Propietarios/Details/5
        public ActionResult Details(int id)
        {
            try {
                // TODO: Add update logic here

                var prop = repo.FindByPrimaryKey(id);
                if (prop.pro_id > 0)
                { TempData["msg"] = "Se encontró.";
                    return View(prop);
                }
                else
                {
                    TempData["msg"] = "Error al abrir el Propietario. Intente nuevamente.";
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Propietarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Propietarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection){
            try{
                // TODO: Add insert logic here
                repo.Put(new Propietario
                {
                    pro_dni = collection["pro_dni"],
                    pro_nombre = collection["pro_nombre"],
                    pro_fechanac = DateTime.Parse(collection["pro_fechanac"]),
                    pro_direc = collection["pro_direc"],
                    pro_telef = collection["pro_telef"],
                    pro_email = collection["pro_email"]
                });
                return RedirectToAction(nameof(Index));
            }
            catch{
                return View();
            }
        }

        // GET: Propietarios/Edit/5
        public ActionResult Edit(int id){
             try {
                // TODO: Add update logic here

                var prop = repo.FindByPrimaryKey(id);
                if (prop.pro_id > 0)
                { TempData["msg"] = "Se encontró.";
                    return View(prop);
                }
                else
                {
                    TempData["msg"] = "No se encontró Propietario. Intente nuevamente.";
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: Propietarios/Edit/5
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

        // GET: Propietarios/Delete/5
        public ActionResult Delete(int id) {
            try
                {
                   var pro = repo.FindByPrimaryKey(id);
                if (pro.pro_id > 0)
                {
                    return View(pro);
                }
                else
                {
                    TempData["msg"] = "No se encontró Propietario. Intente nuevamente.";
                    return RedirectToAction(nameof(Index));
                }
                }
                catch (Exception)
                {
                    throw;
                }
        }

        // POST: Propietarios/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) {
            try
            {
                // TODO: Add delete logic here
                repo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using inmoCabreraNet.Models;

namespace inmoCabreraNet.Controllers
{
    public class InmueblesController : Controller
    {
        RepoInmueble repoInm = new RepoInmueble();
        RepoPropietario repoPropietario = new RepoPropietario();
        // GET: Inmueble
        public ActionResult Index()
        {
            IList<Inmueble> lista = repoInm.All();
            return View(lista);
        }

        // GET: Inmueble/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inmueble/Create
        public ActionResult Create()
        {
            ViewBag.Propietarios = repoPropietario.All();
                // TODO: Add insert logic here

                 return View();
        }

        // POST: Inmueble/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {    
                ViewBag.Propietarios = repoPropietario.All();
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Inmueble/Edit/5
        public ActionResult Edit(int id) {
           try{
                var propietarios = repoPropietario.All();
                if(propietarios.Count != 0){
                    TempData["msg"] = "No se pudo obtener los propietarioss. Intente nuevamente"
                    return RedirectToAction(nameof(Index));              
                }

                ViewBag.Propietarios = propietarios;

                var i = repoInm.FindByPrimaryKey(id);
           }
           catch (Exception e){
                throw;
           }
        }

        // POST: Inmueble/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
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

        // GET: Inmueble/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inmueble/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
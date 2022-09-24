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
                if(propietarios.Count == 0){

                    TempData["msg"] = "No se pudo obtener los propietarioss. Intente nuevamente";
                    return RedirectToAction(nameof(Index));              
                }
              
                ViewBag.Propietarios = propietarios;

                var i = repoInm.FindByPrimaryKey(id);
                
                if(i.inm_id > 0){        
                    var isTaken = repoInm.isTaken(i.inm_id);
                    if (isTaken)
                    {
                        ViewBag.IsTaken = true;
                    }
                    else
                    {
                        ViewBag.IsTaken = false;
                    }
 
                    ViewBag.Tipos = Inmueble.ObtenerTipos();
                    ViewBag.Usos = Inmueble.ObtenerUsos();          
                    return View(i);
                } else {
                    return RedirectToAction(nameof(Index));
                }
           }
           catch (Exception ){
               throw;
                
           }
        }

        // POST: Inmueble/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Inmueble i)
        {
           if (ModelState.IsValid)
                {
                    i.inm_id = id;

                    var isTaken = repoInm.isTaken(id);

                    var res = repoInm.Edit(i, isTaken);
                    if (res > 0)
                    {
                        TempData["msg"] = "Cambios guardados.";
                        return RedirectToAction(nameof(Edit), new { id = id });
                    }
                    else
                    {
                        TempData["msg"] = "No se guardaron los cambios. Intente nuevamente.";
                        return RedirectToAction(nameof(Edit), new { id = id });
                    }
                }
                else
                {
                    TempData["msg"] = "Los datos ingresados no son v�lidos. Intente nuevamente.";
                    return RedirectToAction(nameof(Edit), new { id = id });
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
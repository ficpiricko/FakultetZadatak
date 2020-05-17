using FakultetZadatak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;


namespace FakultetZadatak.Controllers
{
    public class IspitController : Controller
    {
        
        public ActionResult Index(int? page)
        {
            
            IspitDBHandle dbhandle = new IspitDBHandle();
            ModelState.Clear();
          
            return View(dbhandle.VratiIspite().ToPagedList(page ?? 1, 5));
        }

        
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        public ActionResult Create(Ispit ispit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IspitDBHandle idb = new IspitDBHandle();
                    
                    if (idb.DodajIspit(ispit))
                    {
                        ViewBag.Message = "Uspesno ste dodali ispit.";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

      
        public ActionResult Edit(int id)
        {
            IspitDBHandle idb = new IspitDBHandle();
            return View(idb.VratiIspite().Find(ispit => ispit.id == id));
        }

      
        [HttpPost]
        public ActionResult Edit(int id, Ispit ispit)
        {
            try
            {
                IspitDBHandle idb = new IspitDBHandle();
                idb.UpdateIspita(ispit);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Delete(int id)
        {
            try
            {
                IspitDBHandle idb = new IspitDBHandle();
                if (idb.DeleteIspita(id))
                {
                    ViewBag.AlertMsg = "Uspesno ste obrisali ispit.";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace FakultetZadatak.Models
{
    public class StudentController : Controller
    {
        public ActionResult Index(string pretraga,int? page, string sortBy)
        {
            
            StudentDBHandle dbhandle = new StudentDBHandle();
            IspitDBHandle ispitH = new IspitDBHandle();
           

            ModelState.Clear();
            ViewBag.datum_rodjenja = String.IsNullOrEmpty(sortBy) ? "datum_rodjenja desc" : "";
            var studenti = (dbhandle.VratiStudente().ToPagedList(page ?? 1, 5));
           
   
  
            if (!string.IsNullOrEmpty(pretraga))
            {
                
                studenti = dbhandle.VratiStudente().Where(x => x.Ime_i_prezime.StartsWith(pretraga, StringComparison.InvariantCultureIgnoreCase)).ToPagedList(page ?? 1, 5);
               
            }
            switch (sortBy)
            {
                case "datum_rodjenja desc":
                    //studenti = dbhandle.VratiStudente().GroupBy(s => s.grupa_id).Select(s => s.OrderBy(x => x.datum_rodjenja).FirstOrDefault()).ToPagedList(page ?? 1, 5);
                    studenti = dbhandle.VratiStudente().OrderBy(x => x.datum_rodjenja).ToPagedList(page ?? 1, 5);

                    break;

            }

            

            return View(studenti);

            

        }

        // 2. *************Dodaj novog studenta ******************
        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    StudentDBHandle sdb = new StudentDBHandle();
                    if (sdb.DodajStudenta(student))
                    {
                        ViewBag.Message = "Uspesno ste dodali studenta.";
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

        // 3. ************* Izmeni studenta ******************
        // GET: Student/Edit/5
        public ActionResult Edit(int bi)
        {
            StudentDBHandle sdb = new StudentDBHandle();
            return View(sdb.VratiStudente().Find(student => student.bi == bi));
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int bi, Student student)
        {
            try
            {
                StudentDBHandle sdb = new StudentDBHandle();
                sdb.UpdateStudenta(student);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // 4. ************* Brisanje studenta ******************
        // GET: Student/Delete/5
        public ActionResult Delete(int bi)
        {
            try
            {
                StudentDBHandle sdb = new StudentDBHandle();
                if (sdb.BrisanjeStudenta(bi))
                {
                    ViewBag.AlertMsg = "Uspesno obrisan student.";
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppYte.Models;
using PagedList;
namespace WebAppYte.Controllers
{
    public class HoidapController : Controller
    {
        private modelWeb db = new modelWeb();

        // GET: Hoidap
        public ActionResult Index(int ? id, int? page)
        {
            var hoiDaps = db.HoiDaps.Include(h => h.NguoiDung).Include(h => h.QuanTri).Where(h => h.IDNguoiDung == id && h.TrangThai == 1)
                .OrderByDescending(x => x.NgayGui).ThenBy(x => x.IDHoidap).ToList();
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            ViewBag.id = id;
            return View(hoiDaps.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ListAll(int? page)
        {
            if (page == null) page = 1;
            var hoiDaps = db.HoiDaps.Include(h => h.NguoiDung).Include(h => h.QuanTri).Where(n=>n.TrangThai==1)
                .OrderByDescending(x => x.NgayGui).ThenBy(x => x.IDHoidap).ToList();
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(hoiDaps.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Cauhoichoxuly(int? id, int? page)
        {
            var hoiDaps = db.HoiDaps.Include(h => h.NguoiDung).Include(h => h.QuanTri).Where(h => h.IDNguoiDung == id && h.TrangThai == 0)
                .OrderByDescending(x => x.NgayGui).ThenBy(x => x.IDHoidap).ToList();
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            ViewBag.id = id;
            return View(hoiDaps.ToPagedList(pageNumber, pageSize));
        }


        // GET: Hoidap/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoiDap hoiDap = db.HoiDaps.Find(id);
            if (hoiDap == null)
            {
                return HttpNotFound();
            }
            return View(hoiDap);
        }

        // GET: Hoidap/Create
        public ActionResult Create(int? id)
        {
            ViewBag.IDNguoiDung = new SelectList(db.NguoiDungs.Where(h => h.IDNguoiDung==id), "IDNguoiDung", "HoTen");
            ViewBag.IDQuanTri = new SelectList(db.QuanTris, "IDQuanTri", "TaiKhoan");
            return View();
        }

        // POST: Hoidap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDHoidap,CauHoi,TraLoi,IDNguoiDung,IDQuanTri,NgayGui,GhiChu,TrangThai")] HoiDap hoiDap)
        {
            if (ModelState.IsValid)
            {
                var d = DateTime.Now;
                hoiDap.NgayGui = d;
                hoiDap.TrangThai = 0;
                db.HoiDaps.Add(hoiDap);
                db.SaveChanges();
                return RedirectToAction("Index","Hoidap" ,new { id = hoiDap.IDNguoiDung });
            }

            ViewBag.IDNguoiDung = new SelectList(db.NguoiDungs, "IDNguoiDung", "HoTen", hoiDap.IDNguoiDung);
            ViewBag.IDQuanTri = new SelectList(db.QuanTris, "IDQuanTri", "TaiKhoan", hoiDap.IDQuanTri);
            return View(hoiDap);
        }

        // GET: Hoidap/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoiDap hoiDap = db.HoiDaps.Find(id);
            if (hoiDap == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDNguoiDung = new SelectList(db.NguoiDungs.Where(x => x.IDNguoiDung == hoiDap.IDNguoiDung), "IDNguoiDung", "HoTen", hoiDap.IDNguoiDung);
            ViewBag.IDQuanTri = new SelectList(db.QuanTris.Where(x => x.IDQuanTri == hoiDap.IDQuanTri), "IDQuanTri", "HoTen", hoiDap.IDQuanTri);
            return View(hoiDap);
        }

        // POST: Hoidap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDHoidap,CauHoi,TraLoi,IDNguoiDung,IDQuanTri,NgayGui,GhiChu,TrangThai")] HoiDap hoiDap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoiDap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDNguoiDung = new SelectList(db.NguoiDungs, "IDNguoiDung", "HoTen", hoiDap.IDNguoiDung);
            ViewBag.IDQuanTri = new SelectList(db.QuanTris, "IDQuanTri", "TaiKhoan", hoiDap.IDQuanTri);
            return View(hoiDap);
        }

        // GET: Hoidap/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoiDap hoiDap = db.HoiDaps.Find(id);
            if (hoiDap == null)
            {
                return HttpNotFound();
            }
            return View(hoiDap);
        }

        // POST: Hoidap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoiDap hoiDap = db.HoiDaps.Find(id);
            db.HoiDaps.Remove(hoiDap);
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
    }
}

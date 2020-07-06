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
    public class LichkhamController : Controller
    {
        private modelWeb db = new modelWeb();

        // GET: Lichkham
        public ActionResult Index(int? id , int? page)
        {
            var lichKhams = db.LichKhams.Include(l => l.NguoiDung).Include(l => l.QuanTri).
                Where(h => h.IDNguoiDung == id).OrderByDescending(x=>x.BatDau).ThenBy(x=>x.IDLichKham);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            ViewBag.id = id;
            return View(lichKhams.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Dangxuly(int? id, int? page)
        {
            var lichKhams = db.LichKhams.Include(l => l.NguoiDung).Include(l => l.QuanTri).
                Where(h => h.IDNguoiDung == id && h.TrangThai==0).OrderByDescending(x => x.BatDau).ThenBy(x => x.IDLichKham);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            ViewBag.id = id;
            return View(lichKhams.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Daxacnhan(int? id, int? page)
        {
            var lichKhams = db.LichKhams.Include(l => l.NguoiDung).Include(l => l.QuanTri).
                Where(h => h.IDNguoiDung == id && h.TrangThai == 1).OrderByDescending(x => x.BatDau).ThenBy(x => x.IDLichKham);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            ViewBag.id = id;
            return View(lichKhams.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Datuvanxong(int? id, int? page)
        {
            var lichKhams = db.LichKhams.Include(l => l.NguoiDung).Include(l => l.QuanTri).
                Where(h => h.IDNguoiDung == id && h.TrangThai == 2).OrderByDescending(x => x.BatDau).ThenBy(x => x.IDLichKham);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            ViewBag.id = id;
            return View(lichKhams.ToPagedList(pageNumber, pageSize));
        }

        // GET: Lichkham/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichKham lichKham = db.LichKhams.Find(id);
            if (lichKham == null)
            {
                return HttpNotFound();
            }
            return View(lichKham);
        }

        // GET: Lichkham/Create
        public ActionResult Create()
        {
            ViewBag.IDNguoiDung = new SelectList(db.NguoiDungs, "IDNguoiDung", "HoTen");
            ViewBag.IDQuanTri = new SelectList(db.QuanTris.Where(n=>n.VaiTro==2), "IDQuanTri", "HoTen");
            return View();
        }

        // POST: Lichkham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDLichKham,ChuDe,MoTa,BatDau,KetThuc,TrangThai,ZoomInfo,KetQuaKham,IDNguoiDung,IDQuanTri")] LichKham lichKham)
        {
            if (ModelState.IsValid)
            {
                lichKham.TrangThai = 0;
                db.LichKhams.Add(lichKham);
                db.SaveChanges();
                return RedirectToAction("Index","LichKham" ,new { id = lichKham.IDNguoiDung });
            }

            ViewBag.IDNguoiDung = new SelectList(db.NguoiDungs, "IDNguoiDung", "HoTen", lichKham.IDNguoiDung);
            ViewBag.IDQuanTri = new SelectList(db.QuanTris, "IDQuanTri", "HoTen", lichKham.IDQuanTri);
            return View(lichKham);
        }

        // GET: Lichkham/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichKham lichKham = db.LichKhams.Find(id);
            if (lichKham == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDNguoiDung = new SelectList(db.NguoiDungs, "IDNguoiDung", "HoTen", lichKham.IDNguoiDung);
            ViewBag.IDQuanTri = new SelectList(db.QuanTris, "IDQuanTri", "TaiKhoan", lichKham.IDQuanTri);
            return View(lichKham);
        }

        // POST: Lichkham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDLichKham,ChuDe,MoTa,BatDau,KetThuc,TrangThai,ZoomInfo,KetQuaKham,IDNguoiDung,IDQuanTri")] LichKham lichKham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lichKham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDNguoiDung = new SelectList(db.NguoiDungs, "IDNguoiDung", "HoTen", lichKham.IDNguoiDung);
            ViewBag.IDQuanTri = new SelectList(db.QuanTris, "IDQuanTri", "TaiKhoan", lichKham.IDQuanTri);
            return View(lichKham);
        }

        // GET: Lichkham/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichKham lichKham = db.LichKhams.Find(id);
            if (lichKham == null)
            {
                return HttpNotFound();
            }
            return View(lichKham);
        }

        // POST: Lichkham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LichKham lichKham = db.LichKhams.Find(id);
            db.LichKhams.Remove(lichKham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult Lichdangluoi()
        {
            //db.Configuration.ProxyCreationEnabled = false;
            List<LichKham> l = db.LichKhams.ToList();
            // events = db.LichKhams.ToList();
            var events = l.Select(ll => new
            {
                id = ll.IDLichKham,
                title = ll.ChuDe,
                start = ll.BatDau,
                end = ll.KetThuc,
            });
            Console.WriteLine(events);
            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult lichhen()
        {
            return View();

        }
        private static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
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

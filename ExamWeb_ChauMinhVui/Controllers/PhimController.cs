using ExamWeb_ChauMinhVui.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamWeb_ChauMinhVui.Controllers
{
    public class PhimController: Controller

    {
        private readonly ApplicationDbContext _db;

        public PhimController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var dsPhim = _db.Phims.ToList();
            var tongsoluong = _db.Phims.Sum(x => x.Id);
            var max = _db.Phims.Sum(x => x.GiaVe);
            ViewBag.SUM = tongsoluong;
            return View(dsPhim);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Phim phim)
        {
            if (ModelState.IsValid)
            {
                _db.Phims.Add(phim);
                _db.SaveChanges();
                TempData["success"] = "Đã thêm 1 bộ phim";
                return RedirectToAction("Index");
            }
            return View(phim);
        }
        public IActionResult Update(int id)
        {
           
            var phim = _db.Phims.SingleOrDefault(x => x.Id == id);
            if (phim != null)
                return View(phim);

            return NotFound();
        }
        [HttpPost]
        public IActionResult Update(Phim phim)
        {
            if (ModelState.IsValid)
            {
                _db.Phims.Update(phim);
                _db.SaveChanges();
                TempData["success"] = "Đã cập nhật 1 Bộ phim";
                return RedirectToAction("Index");
            }
            return View(phim);
        }
        public IActionResult Delete(int id)
        {
            var phim = _db.Phims.FirstOrDefault(x => x.Id == id);
            if (phim == null)
            {
                return NotFound();
            }
            return View(phim);
        }
        // Xử lý xóa chủng loại
        public IActionResult DeleteConfirmed(int id)
        {
            var phim = _db.Phims.Find(id);
            if (phim == null)
            {
                return NotFound();
            }
            _db.Phims.Remove(phim);
            _db.SaveChanges();
            TempData["success"] = "Category deleted success";
            return RedirectToAction("Index");
        }
    }
}

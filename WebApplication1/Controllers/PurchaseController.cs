using DataAccess.Data;
using Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly AplicationDBContext _db;

        public PurchaseController(AplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Purchase> objList = _db.Purchase.ToList();
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            Purchase obj = new();
            if (id == null || id == 0)
            {
                //create
                return View(obj);
            }
            //edit
            obj = _db.Purchase.FirstOrDefault(u => u.PurchaseId == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Purchase obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.PurchaseId == 0)
                {
                    //create
                    await _db.Purchase.AddAsync(obj);
                }
                else
                {
                    //update
                    _db.Purchase.Update(obj);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Purchase obj = new();

            obj = _db.Purchase.FirstOrDefault(u => u.PurchaseId == id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Purchase.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

      
    }
}

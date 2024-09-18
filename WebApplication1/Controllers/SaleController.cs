using DataAccess.Data;
using Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class SaleController : Controller
    {
        private readonly AplicationDBContext _db;

        public SaleController(AplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Sale> objList = _db.Sales.ToList();
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            Sale obj = new();
            if (id == null || id == 0)
            {
                //create
                return View(obj);
            }
            //edit
            obj = _db.Sales.FirstOrDefault(u => u.SaleId == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Sale obj)
        {

            if (ModelState.IsValid)
            {
                if (obj.SaleId == 0)
                {
                    //create
                    await _db.Sales.AddAsync(obj);
                }
                else
                {
                    //update
                    _db.Sales.Update(obj);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Sale obj = new();

            obj = _db.Sales.FirstOrDefault(u => u.SaleId == id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Sales.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }

}


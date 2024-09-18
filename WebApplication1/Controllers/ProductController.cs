using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Model.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private readonly AplicationDBContext _db;

        public ProductController(AplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Product> objList = _db.Products.ToList();
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            Inventory obj = new();
            if (id == null || id == 0)
            {
                //create
                return View(obj);
            }
            //edit
            obj = _db.Inventory.FirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Inventory obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    //create
                    await _db.Inventory.AddAsync(obj);
                }
                else
                {
                    //update
                    _db.Inventory.Update(obj);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Inventory obj = new();

            obj = _db.Inventory.FirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Inventory.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Model.Models;
using DataAccess.Data;



namespace WebApplication1.Controllers
{
    public class InventoryController : Controller
    {
        private readonly AplicationDBContext _db;

        public InventoryController(AplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Inventory> objList = _db.Inventory.ToList();
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

        public IActionResult CreateMultiple2()
        {
            List<Inventory> inventory = new();
            for (int i = 1; i <= 2; i++)
            {
                inventory.Add(new Inventory { Name = Guid.NewGuid().ToString() });
            }
            _db.Inventory.AddRange(inventory);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple5()
        {
            List<Inventory> inventory = new();
            for (int i = 1; i <= 5; i++)
            {
                inventory.Add(new Inventory { Name = Guid.NewGuid().ToString() });
            }
            _db.Inventory.AddRange(inventory);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple2()
        {
            List<Inventory> inventory = _db.Inventory.OrderByDescending(u => u.Id).Take(2).ToList();
            _db.Inventory.RemoveRange(inventory);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple5()
        {
            List<Inventory> inventory = _db.Inventory.OrderByDescending(u => u.Id).Take(5).ToList();
            _db.Inventory.RemoveRange(inventory);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

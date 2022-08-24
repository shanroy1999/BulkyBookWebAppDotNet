using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{

    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        // tell application that we need an implementation of ApplicationDbContext
        // where connection to database is already made and need to retrieve records

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            // retrieve and convert it to list and assign to variable
            IEnumerable<Category> objCategoryList = _db.Categories;

            // pass object to the view
            return View(objCategoryList);
        }

        // Create GET
        public IActionResult Create()
        {
            // no need to pass a model for the view
            // can create model directly inside the view
            return View();
        }

        // Create POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot be same as the Name");
            }
            // Server Side validation
            if (ModelState.IsValid)
            {
                // create record inside the database
                _db.Categories.Add(obj);        // add to database
                _db.SaveChanges();              // push the changes to the database
                TempData["success"] = "Category has been created Successfully";
                return RedirectToAction("Index"); // redirect to the index action inside the same controller
            }
            return View(obj);
        }

        // Edit GET
        public IActionResult Edit(int? id)
        {
            // check for invalid id
            if(id==null || id == 0)
            {
                return NotFound();
            }

            // extract category for the id in the database
            // id -> primary key -> will always be unique
            // find(id) -> finds the element based on the primary key
            var categoryFromDb = _db.Categories.Find(id);
            var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        // Edit POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot be same as the Name");
            }
            // Server Side validation
            if (ModelState.IsValid)
            {
                // update record inside the database
                _db.Categories.Update(obj);        // update in database
                _db.SaveChanges();              // push the changes to the database
                TempData["success"] = "Category has been updated Successfully";
                return RedirectToAction("Index"); // redirect to the index action inside the same controller
            }
            return View(obj);
        }

        // Delete GET
        public IActionResult Delete(int? id)
        {
            // check for invalid id
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // extract category for the id in the database
            // id -> primary key -> will always be unique
            // find(id) -> finds the element based on the primary key
            var categoryFromDb = _db.Categories.Find(id);
            var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        // Delete POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);      // find category based on the id passed
            if (obj == null)
            {
                return NotFound();
            }
            
            // remove record inside the databases
            _db.Categories.Remove(obj);        // remove from database
            _db.SaveChanges();              // push the changes to the database
            TempData["success"] = "Category has been deleted Successfully";
            return RedirectToAction("Index"); // redirect to the index action inside the same controller
        }
    }
}

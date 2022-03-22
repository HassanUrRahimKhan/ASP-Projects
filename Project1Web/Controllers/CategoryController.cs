using Microsoft.AspNetCore.Mvc;
using Project1Web.Models;
using Project1Web.NewFolder;

namespace Project1Web.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
           IEnumerable<Category> objCategoryList = _db.categories.ToList();
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
           
            return View(); 
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                // ModelState.AddModelError used to add custom Errors
                // 
                ModelState.AddModelError("name", "The display order cannot be the same");
            }



            
            //model state checks in models whether the requirnment checks are valid or not eg required etc
            if (ModelState.IsValid)
            {
                _db.categories.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Created Successfully";
                return RedirectToAction("Index");
                
            }
            else
            {
                return View(obj);
              
            }

        }


        //GET
        public IActionResult Edit(int? id)
        {
            if(id== null || id == 0)
            {
                return NotFound();

            }
            var categoryFromDb = _db.categories.Find(id);
            //var categoryFromDb = _db.categories.FirstOrDefault(c => c.Id == id);

            if(categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                // ModelState.AddModelError used to add custom Errors
                // 
                ModelState.AddModelError("name", "The display order cannot be the same");
            }




            //model state checks in models whether the requirnment checks are valid or not eg required etc
            if (ModelState.IsValid)
            {
                _db.categories.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Updated Successfully";
                return RedirectToAction("Index");

            }
            else
            {
                return View(obj);

            }

        }

        //GET
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();

            }
            var categoryFromDb = _db.categories.Find(id);
            //var categoryFromDb = _db.categories.FirstOrDefault(c => c.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST (int? id)
        {
            
                
            
                var obj = _db.categories.Find(id);
                //var categoryFromDb = _db.categories.FirstOrDefault(c => c.Id == id);

                if (obj == null) 
                {
                    return NotFound();
                }

                _db.categories.Remove(obj);
                _db.SaveChanges();
            TempData["Success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");



          

            

        }



    }
}

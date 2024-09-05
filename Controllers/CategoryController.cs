using Microsoft.AspNetCore.Mvc;
using NewProjectOnMVCFullStack.Models;

namespace NewProjectOnMVCFullStack.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DbContextClass _dbContextClass; 
        public CategoryController(DbContextClass dbContextClass)
        {
            _dbContextClass = dbContextClass;
        }
        [Route("categories")]
        public IActionResult Categories()
        {
            List<Categories>listOfcat=_dbContextClass.Category.ToList();
            return View(listOfcat);
        }
        [Route("categories/add")]
        public IActionResult AddCategories()
        {
            Categories categories = new Categories();
            return View(categories);
        }
        [HttpPost]
        public IActionResult PostAddCategories(Categories cat)
        {
            Categories catOne=new Categories();
            catOne.CategoryName = cat.CategoryName;
            _dbContextClass.Category.Add(catOne);
            _dbContextClass.SaveChanges();
            return View();
        }

        [Route("categories/update")]
        public IActionResult UpdateCategory(int id)
        {
            
            Categories categories = _dbContextClass.Category.Find(id);
            return View(categories);
        }
        [HttpPost]
        public IActionResult UpdateCategoryPost(Categories cat)
        {
           Categories? categories = _dbContextClass.Category.Find(cat.CategoryId);
            categories.CategoryName = cat.CategoryName;
            _dbContextClass.Category.Update(categories);
            _dbContextClass.SaveChanges();
            return View();
        }
        [Route("categories/delete")]
        public IActionResult DeleteCategory(int id)
        {

            Categories categories = _dbContextClass.Category.Find(id);
            return View(categories);
        }
        [HttpPost]
        public IActionResult DeleteCategoryPost(Categories cat)
        {
            Categories? categories = _dbContextClass.Category.Find(cat.CategoryId);
            _dbContextClass.Category.Remove(categories);
            _dbContextClass.SaveChanges();
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using NewProjectOnMVCFullStack.Models;

namespace NewProjectOnMVCFullStack.Controllers
{
    public class ProductController : Controller
    {
        private readonly DbContextClass _dbContextClass;
        public ProductController(DbContextClass dbContextClass)
        {
            _dbContextClass = dbContextClass;
        }
        [Route("products")]
        public IActionResult Products()
        {
            List<Products> listOfcat = _dbContextClass.Product.ToList();
            return View(listOfcat);
        }
        [Route("products/add")]
        public IActionResult AddProducts()
        {
            Products products = new Products();
            return View(products);
        }
        [HttpPost]
        public IActionResult PostAddProducts(Products cat)
        {
            Products catOne = new Products();
            catOne.ProductName=cat.ProductName;
            catOne.Price=cat.Price;
            catOne.QtyAvailable=cat.QtyAvailable;
            _dbContextClass.Product.Add(catOne);
            _dbContextClass.SaveChanges();
            return View();
        }

        [Route("products/update")]
        public IActionResult UpdateProducts(int id)
        {

            Products categories = _dbContextClass.Product.Find(id);
            return View(categories);
        }
        [HttpPost]
        public IActionResult UpdateProductsPost(Products cat)
        {
            Products? categories = _dbContextClass.Product.Find(cat.CategoryId);
            categories.ProductName = cat.ProductName;
            categories.Price = cat.Price;
            categories.QtyAvailable = cat.QtyAvailable;
            _dbContextClass.Product.Update(categories);
            _dbContextClass.SaveChanges();
            return View();
        }
        [Route("products/delete")]
        public IActionResult DeleteProducts(int id)
        {

            Products categories = _dbContextClass.Product.Find(id);
            return View(categories);
        }
        [HttpPost]
        public IActionResult DeleteProductsPost(Products cat)
        {
            Products? categories = _dbContextClass.Product.Find(cat.CategoryId);
            _dbContextClass.Product.Remove(categories);
            _dbContextClass.SaveChanges();
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using NewProjectOnMVCFullStack.Models;
using System.Diagnostics;

namespace NewProjectOnMVCFullStack.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbContextClass _dbContextClass;
        public HomeController(ILogger<HomeController> logger, DbContextClass dbContext)
        {
            _logger = logger;
            _dbContextClass= dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("Home")]
        public IActionResult Home(Users user)
        {

            return View(user);
        }
        [Route("/")]
        public IActionResult Login()
        {
            return View();
            
        }
        [HttpPost]
        public IActionResult PostLogin(Users userInput)
        {
            var isPresent = _dbContextClass.Users.Where(x=>x.Password == userInput.Password).Select(x=>x.UserName).ToList();
            if (isPresent.Count>0)
            {
                return RedirectToAction("Home");
            }
            else
            {
                return RedirectToAction("register");
            }
        }
        [Route("register")]
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public IActionResult PostRegister(Users user)
        {
            if(ModelState.IsValid)
            {
                _dbContextClass.Users.Add(user);
                _dbContextClass.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                List<string>listOfErrors=ModelState.Values.SelectMany(x=>x.Errors).Select(x=>x.ErrorMessage).ToList();

                return Content("\n"+listOfErrors.ToString(), "text/plain");
            }
           
        }
        [Route("logout")]
        public IActionResult Logout()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
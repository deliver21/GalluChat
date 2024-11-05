using GalluChat.Models;
using GalluChat.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Diagnostics;

namespace GalluChat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                // Redirect to the main chat page or dashboard
                //TempData["FoundFriend"] = Convert.ToString(TempData["FoundFriend"]);
                return RedirectToAction("Index", "Chat");
            }
            return View();
        }
        [HttpPost]
        public IActionResult FindFriend(string friend)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser userFromDb = _unitOfWork.ApplicationUser.Get(u => u.UserName == friend);
                if (userFromDb != null)
                {
                    TempData["FoundFriend"] =JsonConvert.SerializeObject(userFromDb); // Pass the user to the view
                    RedirectToAction("Index", "Chat",userFromDb);
                }
            }
            return RedirectToAction("Index","Chat"); // Redirect to the main view where partial will be included
        }   
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
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
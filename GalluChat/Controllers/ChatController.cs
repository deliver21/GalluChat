using GalluChat.Models;
using GalluChat.Models.ViewModel;
using GalluChat.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace GalluChat.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ChatController(IUnitOfWork unitOfWork)
        { 
            _unitOfWork = unitOfWork;
        }
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    //Get UserId
        //    var claimsIdentity = (ClaimsIdentity)User.Identity;
        //    var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;


        //    ChatVM ChatMV =new ChatVM()
        //    {
        //        Users= _unitOfWork.ApplicationUser.GetAll(u => u.Id != userId),
        //        UserFound=new(),
        //        Chat=new()
        //    };

        //    //Find User Logic
        //    string searchResult = Convert.ToString(TempData["FoundFriend"]);
        //    if (!string.IsNullOrEmpty(searchResult))
        //    {
        //        ChatMV.UserFound = JsonConvert.DeserializeObject<ApplicationUser>(searchResult);
        //    }
        //    return View(ChatMV);
        //}
        [HttpGet]
        public IActionResult Index()
        {
            // Get UserId
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ChatVM ChatMV = new ChatVM()
            {
                Users = _unitOfWork.ApplicationUser.GetAll(u => u.Id != userId),
                UserFound = new ApplicationUser(),
                Chat = new Chat() // Assuming Chat is a class or initialize it as per your need
            };

            // Deserialize the found user from TempData
            if (TempData["FoundFriend"] != null)
            {
                var searchResult = Convert.ToString(TempData["FoundFriend"]);
                if (!string.IsNullOrEmpty(searchResult))
                {
                    ChatMV.UserFound = JsonConvert.DeserializeObject<ApplicationUser>(searchResult);
                }
            }

            // Optional: Retrieve message if set
            ViewBag.Message = TempData["Message"]?.ToString();
            return View(ChatMV);
        }

        [HttpPost]
        public IActionResult GetFriend(string? searchFriend)
        {
            if (!string.IsNullOrEmpty(searchFriend))
            {
                var userFromDb = _unitOfWork.ApplicationUser.Get(u => u.UserName == searchFriend);
                if (userFromDb != null)
                {
                    TempData["FoundFriend"] = JsonConvert.SerializeObject(userFromDb); // Serialize user data to TempData
                }
                else
                {
                    TempData["Message"] = "User not found"; // Optional: Set a message if the user is not found
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult OpenChat(string userId)
        {
            //Get UserId
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userAuthor = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            var chat = _unitOfWork.Chat.Get(u => u.UserId == userId);
            if(chat==null)
            {
                chat = new();
                chat.UserId = userId;
                _unitOfWork.Chat.Add(chat);
                _unitOfWork.Save();
            }
            return RedirectToAction(nameof(Index),chat);
        }
    }
}

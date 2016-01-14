using IBet.Domain.Core;
using IBet.Infrastructure.Data;
using IBetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IBetApp.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        const int COUNT_OF_BEST_USERS = 10;
        const int COUNT_OF_NEW_BETS = 10;
        public ActionResult Index()
        {
            HomePageViewModel model = new HomePageViewModel();
            try
            {
                model.Users = AutoMapper.Mapper.Map<IEnumerable<TopUserViewModel>>(unitOfWork.UsersRepository.GetTopBestByBets(COUNT_OF_BEST_USERS).ToList());
                var user = model.Users.FirstOrDefault();
                model.Bets = AutoMapper.Mapper.Map<IEnumerable<NewBetsViewModel>>(unitOfWork.BetsRepository.GetTheNewestBets(COUNT_OF_NEW_BETS).ToList());
            }
            catch (Exception ex)
            {

            }
            return View(model);
        }

        public ActionResult AllUsers()
        {
            List<UserSummaryViewModel> model = AutoMapper.Mapper.Map<IEnumerable<UserSummaryViewModel>>(unitOfWork.UsersRepository.GetAll()).ToList();
            return View(model);
        }

        public ActionResult ViewUserPage(string id)
        {
            UserInfoViewModel model = AutoMapper.Mapper.Map<UserInfoViewModel>(unitOfWork.UsersRepository.Get(id));
            
            if (User.Identity.Name != model.UserName)
            {
                //if (t.Where(f => !f.IsDeleted &&
                //       ((f.UserId == model.Id && f.UserFriend.UserName == User.Identity.Name) ||
                //       (f.UserFriendId == model.Id && f.User.UserName == User.Identity.Name))).Count() > 0)
                //if (User.Identity.Name != model.UserName &&
                //      t.Where(f => !f.IsDeleted &&
                //      f.UserFriendId == model.Id && f.User.UserName == User.Identity.Name).Count() > 0)
                if(unitOfWork.FriendsRepository.Get(User.Identity.Name, id) != null)
                {
                    ViewBag.AreFriend = "true";
                }
                else
                {
                    ViewBag.AreFriend = "false";
                } 
            }
            return View("~/Views/Manage/Profile.cshtml", model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
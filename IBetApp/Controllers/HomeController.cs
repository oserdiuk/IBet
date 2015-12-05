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
        const int COUNT_OF_NEW_BETS  = 10;
        public ActionResult Index()
        {
            HomePageViewModel model = new HomePageViewModel();
            model.Users = unitOfWork.UsersRepository.GetTopBestByBets(COUNT_OF_BEST_USERS);
            var user = model.Users.FirstOrDefault();
            model.Bets = unitOfWork.BetsRepository.GetTheNewestBets(COUNT_OF_NEW_BETS);
            return View(model);
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
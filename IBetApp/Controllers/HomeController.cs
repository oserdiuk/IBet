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
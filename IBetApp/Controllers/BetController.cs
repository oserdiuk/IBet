using IBet.Data.Repositories;
using IBet.Domain.Core;
using IBet.Infrastructure.Data;
using IBetApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IBetApp.Controllers
{
    public class BetController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Bet
        public ActionResult Index()
        {
            IEnumerable<BetInfoViewModel> bets = AutoMapper.Mapper.Map<IEnumerable<BetInfoViewModel>>(unitOfWork.BetsRepository.GetPublicBets());
            return View(bets);
        }

        public ActionResult UserBets()
        {
            string userId = unitOfWork.UsersRepository.GetByUserName(User.Identity.Name).Id;
            var usersInBet = unitOfWork.UsersInBetRepository.GetAll().ToList();
            var bets = usersInBet.Where(b => b.UserId == userId).Select(u => u.Bet).ToList<Bet>();
            IEnumerable<BetInfoViewModel> betsInfo = AutoMapper.Mapper.Map<IEnumerable<BetInfoViewModel>>(bets);
            ViewBag.IsMyBets = true;
            return View("AllBets", betsInfo);
        }

        // GET: Bet/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bet/Create
        [HttpPost]
        public ActionResult CreateWithMultipleUsers(IEnumerable<string> users = null)
        {
            if (users == null) return RedirectToAction("AllUsers", "Home");
            CreateBetViewModel model = new CreateBetViewModel();
            model.Users = AutoMapper.Mapper.Map<IEnumerable<UserInfoViewModel>>(unitOfWork.UsersRepository.GetAll().Where(u => users.Contains(u.Id)).ToList());
            model.AddInterests(unitOfWork.InterestsRepository.GetAll().ToList());
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateBet(string jsonModel)
        {
            try
            {
                CreateBetViewModel model = JsonConvert.DeserializeObject<CreateBetViewModel>(jsonModel);
                Bet bet = AutoMapper.Mapper.Map<CreateBetViewModel, Bet>(model);
                bet.StatusId = BetsRepository.GetStatusNumber(BetStatus.Applying);
                bet.Interest = unitOfWork.InterestsRepository.Get(bet.InterestId);
                unitOfWork.BetsRepository.Create(bet);
                bet.Id = unitOfWork.BetsRepository.GetAll().LastOrDefault().Id;
                string curUserId = unitOfWork.UsersRepository.GetAll().Where(u => u.UserName == User.Identity.Name).FirstOrDefault().Id;
                unitOfWork.Save();
                unitOfWork.UsersInBetRepository.CreateForUser(curUserId, bet);
                foreach (var user in model.Users)
                {
                    unitOfWork.UsersInBetRepository.CreateForUser(user.Id, bet);
                }

                ViewBag.SuccesCreateBet = true;
                unitOfWork.Save();
                RedirectToAction("AllBets", "Bet");
            }
            catch (Exception ex)
            {

                throw;
            }
            return RedirectToAction("AllUsers", "Home");
        }

        public ActionResult AllBets()
        {
            List<BetInfoViewModel> bets = AutoMapper.Mapper.Map<IEnumerable<BetInfoViewModel>>(unitOfWork.BetsRepository.GetAll()).ToList();
            if (ViewBag.SuccesCreateBet == true) ViewBag.SuccesCreateBet = true;
            return View(bets);
        }

        public PartialViewResult RemoveUserFromBet(string jsonModel, string id)
        {
            try
            {
                var users = JsonConvert.DeserializeObject<IEnumerable<UserInfoViewModel>>(jsonModel).ToList();
                users.Remove(users.Where(u => u.Id == id).FirstOrDefault());
                if (users.Count == 0)
                {
                    ViewBag.NoUsersChosen = "There is no users. Go back and chose one";
                }
                return PartialView("UsersListPartialView", users);

            }
            catch (Exception ex)
            {

                throw;
            }
            return null;
        }

        // POST: Bet/Create
        [HttpPost]
        public ActionResult Create(CreateBetViewModel model)
        {
            if (ModelState.IsValid)
            {
                Bet bet = AutoMapper.Mapper.Map<Bet>(model);
                bet.StatusId = BetsRepository.GetStatusNumber(BetStatus.Applying);
                unitOfWork.BetsRepository.Create(bet);
                unitOfWork.Save();
                RedirectToAction("Index");
            }
            return View(model);
        }

        public void AddMoney(AddingUserMoneyViewModel model)
        {
            unitOfWork.UsersRepository.Get(model.UserId).MoneyLeft += model.MoneyToAdd;
            unitOfWork.Save();
        }

        //TODO Win or lose. Think about database. How to do it
        //public ActionResult Win(int betId)
        //{
        //    unitOfWork.UsersInBetRepository.Get(betId, User.Identity.Name).IsWinner = true;
        //    unitOfWork.Save();
        //}
        //public ActionResult Lose(int betId)
        //{
        //    unitOfWork.UsersInBetRepository.Get(betId, User.Identity.Name).IsWinner = false;
        //    unitOfWork.Save();
        //}

        // GET: Bet/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bet/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bet/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bet/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

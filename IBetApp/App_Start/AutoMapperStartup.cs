using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IBet.Domain.Core;
using IBetApp.Models;
using IBet.Data.Repositories;

namespace IBetApp.App_Start
{
    public class AutoMapperStartup
    {
        public static void InitializeMapper()
        {
            Mapper.CreateMap<ApplicationUser, RegisterViewModel>();
            Mapper.CreateMap<RegisterViewModel, ApplicationUser>();

            Mapper.CreateMap<ApplicationUser, TopUserViewModel>()
                .ForMember("PictureName", m => m.MapFrom(src => src.ImageName))
                .ForMember("NumberOfVictories", m => m.MapFrom(src => src.UserInBets.Where(u => u.IsWinner && u.UserId == src.Id).Count()));
            Mapper.CreateMap<Bet, NewBetsViewModel>().ForMember("Time", m => m.MapFrom(src => src.StartDate))
            .ForMember("Money", m => m.MapFrom(src => src.MoneySum))
            .ForMember("BetInterest", m => m.MapFrom(src => src.Interest.InterestTitle));


            Mapper.CreateMap<Bet, CreateBetViewModel>()
                .ForMember("InterestName", m => m.MapFrom(src => src.Interest.InterestTitle));
            Mapper.CreateMap<CreateBetViewModel, Bet>()
                        .ForMember("InterestId", m => m.MapFrom(src => Convert.ToInt32(src.InterestName)));

            Mapper.CreateMap<Bet, BetInfoViewModel>().ForMember("InterestName", m => m.MapFrom(src => src.Interest.InterestTitle));

            Mapper.CreateMap<ApplicationUser, UserInfoViewModel>();
            Mapper.CreateMap<News, NewsInfoViewModel>();
            Mapper.CreateMap<ApplicationUser, UserSummaryViewModel>();
        }

    }
}

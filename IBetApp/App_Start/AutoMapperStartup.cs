using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IBet.Domain.Core;
using IBetApp.Models;

namespace IBetApp.App_Start
{
    public class AutoMapperStartup
    {
        public static void InitializeMapper()
        {
            Mapper.CreateMap<ApplicationUser, RegisterViewModel>();
            Mapper.CreateMap<RegisterViewModel, ApplicationUser>();


        }
    }
}

using AutoMapper;
using FATEA.ProjetoPoster.Web.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATEA.ProjetoPoster.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<ViewModelParaDominioProfile>();
                config.AddProfile<DominioParaViewModelProfile>();
            });
        }
    }
}
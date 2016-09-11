using AutoMapper;
using FATEA.ProjetoPoster.Domain;
using FATEA.ProjetoPoster.Web.ViewModels.Evento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATEA.ProjetoPoster.Web.AutoMapper
{
    public class DominioParaViewModelProfile : Profile
    {
        protected override void Configure()
        {
            
            Mapper.CreateMap<Evento, EventoIndexViewModel>();
            Mapper.CreateMap<Evento, EventoEdicaoViewModel>();
        }
    }
}
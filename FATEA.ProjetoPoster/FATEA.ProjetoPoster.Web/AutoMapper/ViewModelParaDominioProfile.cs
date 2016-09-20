using AutoMapper;
using FATEA.ProjetoPoster.Domain;
using FATEA.ProjetoPoster.Web.ViewModels.Curso;
using FATEA.ProjetoPoster.Web.ViewModels.Evento;
using FATEA.ProjetoPoster.Web.ViewModels.Poster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FATEA.ProjetoPoster.Web.AutoMapper
{
    public class ViewModelParaDominioProfile : Profile
    {
        protected override void Configure()
        {
           
            Mapper.CreateMap<EventoEdicaoViewModel, Evento>();
            Mapper.CreateMap<PosterEdicaoViewModel, Poster>();
            Mapper.CreateMap<CursoEdicaoViewModel, Curso>();
        }

    }
}
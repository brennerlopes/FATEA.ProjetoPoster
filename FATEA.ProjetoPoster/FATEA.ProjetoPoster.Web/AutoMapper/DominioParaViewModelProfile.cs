using AutoMapper;
using FATEA.ProjetoPoster.Domain;
using FATEA.ProjetoPoster.Web.ViewModels.Curso;
using FATEA.ProjetoPoster.Web.ViewModels.Avaliacao;
using FATEA.ProjetoPoster.Web.ViewModels.Evento;
using FATEA.ProjetoPoster.Web.ViewModels.Poster;
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
            Mapper.CreateMap<Curso, CursoIndexViewModel>();
            Mapper.CreateMap<Curso, CursoEdicaoViewModel>();
            Mapper.CreateMap<Evento, EventoIndexViewModel>();
            Mapper.CreateMap<Evento, EventoEdicaoViewModel>();
            Mapper.CreateMap<Poster, PosterIndexViewModel>();
            Mapper.CreateMap<Poster, PosterEdicaoViewModel>();
            // Avaliacao
            Mapper.CreateMap<Avaliacao, AvaliacaoIndexViewModel>()
                .ForMember(m => m.TituloPoster, config =>
                {
                    config.MapFrom(src => src.Poster.Titulo);
                });
            Mapper.CreateMap<Avaliacao, AvaliacaoDetalhesViewModel>()
                .ForMember(m => m.TituloPoster, config =>
                {
                    config.MapFrom(src => src.Poster.Titulo);
                });

        }
    }
}
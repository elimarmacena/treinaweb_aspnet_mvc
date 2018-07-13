using AutoMapper;
using ERM.Musicas.Dominio;
using ERM.Musicas.Web.ViewModels.Album;
using ERM.Musicas.Web.ViewModels.Musica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERM.Musicas.Web.AutoMapper
{
    public class DominioToViewModelProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Album, AlbumShowViewModel>()
                .ForMember(a => a.Nome, opt =>
                {
                    opt.MapFrom(src =>
                        string.Format("{0} ({1})", src.Nome, src.Ano.ToString())
                    );
                });
            Mapper.CreateMap<Album, AlbumViewModel>();
            Mapper.CreateMap<Musica, MusicaShowViewModel>()
                .ForMember(p => p.NomeAlbum, opt =>
                {
                    opt.MapFrom(src => src.Album.Nome);
                }
                    );
            Mapper.CreateMap<Musica, MusicaViewModel>();
        }
    }
}
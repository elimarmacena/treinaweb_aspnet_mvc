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
    public class ViewModelToDominioProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<AlbumViewModel, Album>();
            Mapper.CreateMap<MusicaViewModel, Musica>();
        }
    }
}
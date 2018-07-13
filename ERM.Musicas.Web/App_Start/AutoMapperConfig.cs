using AutoMapper;
using ERM.Musicas.Web.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERM.Musicas.Web.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configurar()
        {
            Mapper.AddProfile<DominioToViewModelProfile>();
            Mapper.AddProfile<ViewModelToDominioProfile>();
        }
    }
}
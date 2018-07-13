using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERM.Musicas.Web.Identity
{
    public class MusicasIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public MusicasIdentityDbContext()
            :base("MusicasDbContext")
        {

        }
    }
}
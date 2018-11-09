using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ActividadesComplementarias.Models;

namespace ActividadesComplementarias.Models
{
    public class ActividadesComplementariasContext : DbContext
    {
        public ActividadesComplementariasContext (DbContextOptions<ActividadesComplementariasContext> options)
            : base(options)
        {
        }

        public DbSet<ActividadesComplementarias.Models.estado> estado { get; set; }

        public DbSet<ActividadesComplementarias.Models.grupo> grupo { get; set; }
    }
}

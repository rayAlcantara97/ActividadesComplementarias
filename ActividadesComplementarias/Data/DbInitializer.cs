using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActividadesComplementarias.Models;

namespace ActividadesComplementarias.Data
{
    public class DbInitializer
    {
        public static void Initialize(ActividadesComplementariasContext context)
        {
            context.Database.EnsureCreated();
            if (context.estado.Any())
            {
                return;
            }
            var estado = new estado[]
            {
                //
};
            foreach (estado a in estado)
            {
                context.estado.Add(a);
            }
            context.SaveChanges();
            }
        }
    }


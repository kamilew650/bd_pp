using PublicTransportApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublicTransportApi.Core
{
    public static class DbInitializer
    {
        public static void Initialize(DefaultDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.BusStops.Any())
            {
                return;
            }

            BusStop busStop = new BusStop() { Name = "Halemba Pętla", Address = "Ruda Śląska, Pętlowa 12" };
            context.BusStops.Add(busStop);
            context.SaveChanges();
        }
    }
}

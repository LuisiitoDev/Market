using luigiDev.Market.DataAccess.Identity.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace luigiDev.Market.DataAccess.Identity
{
    public class IdentityDBContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.NamesToSnakeCase();
        }
    }
}

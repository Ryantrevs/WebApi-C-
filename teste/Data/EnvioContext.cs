using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teste.Models;

namespace teste.Data
{
    public class EnvioContext : DbContext
    {

        public DbSet<Cliente> clientes { get; set; }

        public EnvioContext(DbContextOptions<EnvioContext> opt):base(opt)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Cliente>().HasKey(t=>t.id);
            

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Renta_Car.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Renta_Car.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Vehiculos> Vehiculos { get; set; }
        public DbSet<Proveedores>  Proveedores { get; set; }
        public DbSet<Alquileres> Alquileres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = .\SQLEXPRESS; Database = RentaDb; Trusted_Connection = True; ");
        }
    }
}

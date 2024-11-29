using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Cateing.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Catering.Data.Migrations
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Bebida> Bebidas { get; set; }
        public virtual DbSet<Bebida_Reserva> Bebida_Reserva{ get; set; }
        public virtual DbSet<Calificacion> Calificacion {  get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Cuenta_Cliente> Cuenta_Cliente { get; set; }
        public virtual DbSet<Cuenta_Propietario> Cuenta_Propietarios { get; set; }
        public virtual DbSet<Descuentos> Descuentos { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Imagenes_Empresa> Imagenes_Empresas { get; set; }
        public virtual DbSet<Menu_Bebida_Reserva> Menu_Bebida_Reservas { get; set; }
        public virtual DbSet<Menu_Platillo_Reserva> Menu_Platillo_Reservas{ get; set; }
        public virtual DbSet<Menu_Reserva> Menu_Reservas { get; set; }
        public virtual DbSet<Platillo> Platillos { get; set; }
        public virtual DbSet<Platillo_Reserva> Platillo_Reservas { get; set; }
        public virtual DbSet<Propietario_Empresa> Propietario_Empresas{ get; set; }
        public virtual DbSet<Reserva> Reserva {  get; set; }
        public virtual DbSet<Reserva_Dirreccions> Reserva_Dirreccion { get; set; }
        public virtual DbSet<Reserva_Info_Cliente> Reserva_Info_Clientes { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Definimos la primary key de Bebida
            modelBuilder.Entity<Bebida>()
                .HasKey(b => b.id_bebida);
            //Definimos la primary key de Bebida_Reserva
            modelBuilder.Entity<Bebida_Reserva>()
                .HasKey(br => br.id_bebida);
            ///
            modelBuilder.Entity<Menu_Bebida_Reserva>()
                .HasKey(m => new { m.id_menu, m.id_menu_bebida });
            //
            modelBuilder.Entity<Menu_Platillo_Reserva>()
                .HasKey(m => new { m.id_menu, m.id_menu_platillo });
        }
    }
}
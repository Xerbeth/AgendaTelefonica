#region Referencias 
using Common.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace DataAccessLayer
{
    /// <summary>
    /// Clase generada automaticamente por el ET para la conección a la DB 
    /// </summary>
    public partial class DbContextApp : DbContext
    {
        public DbContextApp()
            : base("name=DbContextAgendaTelefonica")
        {
        }

        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<cargos> cargos { get; set; }
        public virtual DbSet<Descripcion> Descripcion { get; set; }
        public virtual DbSet<empleados> empleados { get; set; }
        public virtual DbSet<telefonos> telefonos { get; set; }
        public virtual DbSet<tiposdocumentos> tiposdocumentos { get; set; }
        public virtual DbSet<tipostelefonos> tipostelefonos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cargos>()
                .Property(e => e.Cargo)
                .IsUnicode(false);

            modelBuilder.Entity<cargos>()
                .HasMany(e => e.empleados)
                .WithRequired(e => e.cargos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Descripcion>()
                .Property(e => e.Tipo_Documento)
                .IsUnicode(false);

            modelBuilder.Entity<Descripcion>()
                .Property(e => e.Descripcion1)
                .IsUnicode(false);

            modelBuilder.Entity<empleados>()
                .Property(e => e.NumeroDocumento)
                .IsUnicode(false);

            modelBuilder.Entity<empleados>()
                .Property(e => e.Primer_Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<empleados>()
                .Property(e => e.Segundo_Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<empleados>()
                .Property(e => e.Primer_Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<empleados>()
                .Property(e => e.Segundo_Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<empleados>()
                .HasMany(e => e.empleados1)
                .WithOptional(e => e.empleados2)
                .HasForeignKey(e => e.Jefe);

            modelBuilder.Entity<empleados>()
                .HasMany(e => e.telefonos)
                .WithRequired(e => e.empleados)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<telefonos>()
                .Property(e => e.NumeroTelefonico)
                .IsUnicode(false);

            modelBuilder.Entity<tiposdocumentos>()
                .Property(e => e.Tipo_Documento)
                .IsUnicode(false);

            modelBuilder.Entity<tiposdocumentos>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<tiposdocumentos>()
                .HasMany(e => e.empleados)
                .WithRequired(e => e.tiposdocumentos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tipostelefonos>()
                .Property(e => e.Tipo_Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<tipostelefonos>()
                .HasMany(e => e.telefonos)
                .WithRequired(e => e.tipostelefonos)
                .WillCascadeOnDelete(false);
        }
    }
}

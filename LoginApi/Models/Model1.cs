namespace LoginApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<materia> materia { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<materia>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<materia>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.usu)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.passw)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.telefono)
                .IsUnicode(false);
        }
    }
}

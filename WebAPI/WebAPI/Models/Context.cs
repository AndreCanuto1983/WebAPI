using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Teste.Models;

namespace WebAPI.Models
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public Context()
           : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        #region [ DBSet Core]

        public DbSet<VehicleModels> Vehicle { get; set; }

        #endregion

        #region Configuration

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Desativa o esquema de cascata
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<VehicleModels>()
            .Property(w => w.observacao)
            .HasColumnType("text");
        }

        #endregion
    }
}
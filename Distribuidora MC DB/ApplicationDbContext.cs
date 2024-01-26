using Distribuidora_MC_DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Distribuidora_MC_DB
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<InformacionProducto> informacionProductos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Precio> Precios { get; set; }

        public string DbPath { get; }
        public ApplicationDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "DistribuidoraMC.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de relaciones aquí
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.CategoriaId);

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Proveedor)
                .WithMany(pr => pr.Productos)
                .HasForeignKey(p => p.ProveedorId);

            // Otras configuraciones de relaciones...

            // Puedes agregar más configuraciones según tus necesidades
        }

    }

}

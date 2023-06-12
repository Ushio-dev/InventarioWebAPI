using InventarioWebAPI.models;
using Microsoft.EntityFrameworkCore;

namespace InventarioWebAPI.Data
{
	public class DbInventario : DbContext
	{
		public DbSet<Producto> Productos { get; set; }
		public DbSet<Categoria> Categorias { get; set; }

		public DbInventario(DbContextOptions<DbInventario> options) : base(options) { }


	}
}

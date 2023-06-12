using System.Text.Json.Serialization;

namespace InventarioWebAPI.models
{
	public class Producto
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public int Stock { get; set; }
		public int CategoriaId { get; set; }
		public Categoria Categoria { get; set; }
	}
}

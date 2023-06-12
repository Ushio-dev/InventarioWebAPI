using InventarioWebAPI.models;
using System.Text.Json.Serialization;

namespace InventarioWebAPI.dtos
{
	public class ProductoDto
	{
		public string Nombre { get; set; }
		public int stock { get; set; }
		public int CategoriaId { get; set; }
	}
}

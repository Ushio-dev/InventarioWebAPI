using InventarioWebAPI.Data;
using InventarioWebAPI.dtos;
using InventarioWebAPI.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventarioWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductoController : ControllerBase
	{
		private readonly DbInventario _db;
		public ProductoController(DbInventario db) 
		{
			_db = db;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Producto>>> GetAll()
		{
			var productos = await _db.Productos.Include(p => p.Categoria).ToListAsync();

			return Ok(productos);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Producto>> Get(int id)
		{
			var productos = await _db.Productos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.Id == id);

			return productos;
		}

		[HttpPost]
		public async Task<ActionResult<Producto>> Create(ProductoDto producto)
		{
			var categoria = await _db.Categorias.FindAsync(producto.CategoriaId);

			var newProducto = new Producto
			{
				Nombre = producto.Nombre,
				Stock = producto.stock,
				CategoriaId = producto.CategoriaId,
				Categoria = categoria
			};

			_db.Productos.Add(newProducto);
			await _db.SaveChangesAsync();

			return await Get(newProducto.Id);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<Producto>> Update(ProductoDto producto, int id)
		{
			var updateProd = await _db.Productos.FindAsync(id);

			updateProd.Nombre = producto.Nombre;
			updateProd.Stock = producto.stock;
			updateProd.CategoriaId = producto.CategoriaId;

			await _db.SaveChangesAsync();

			return updateProd;
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<Producto>> Delete(int id)
		{
			var prod = await _db.Productos.FindAsync(id);
			_db.Remove(prod);
			await _db.SaveChangesAsync();

			return prod;
		}

		[HttpGet("search/")]
		public async Task<ActionResult<IEnumerable<Producto>>> GetByCategoria([FromQuery] int id)
		{
			var productos = await _db.Productos.Include(c => c.Categoria).Where(p => p.CategoriaId == id).ToListAsync();

			return productos;
		}
	}
}

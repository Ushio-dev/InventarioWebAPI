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
	public class CategoriaController : ControllerBase
	{
		private readonly DbInventario _db;

		public CategoriaController(DbInventario db)
		{
			_db = db;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Categoria>>> GetAll()
		{
			return await _db.Categorias.ToListAsync();
		}

		[HttpPost]
		public async Task<ActionResult<Categoria>> Create(CategoriaDto categoria)
		{
			var newCategoria = new Categoria
			{
				Nombre = categoria.Nombre,
			};

			_db.Categorias.Add(newCategoria);
			await _db.SaveChangesAsync();

			return Ok(categoria);
		}
	}
}

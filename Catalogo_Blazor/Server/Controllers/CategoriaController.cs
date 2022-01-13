using Catalogo_Blazor.Server.Context;
using Catalogo_Blazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo_Blazor.Server.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly AppDbContext context;

        public CategoriaController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet("todas")]
        public async Task<ActionResult<List<Categoria>>> Get()
        {
            return await context.Categorias
                .AsNoTracking()
                .ToListAsync();
        }

        [HttpGet("{id}", Name ="GetCategoria")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            return await context.Categorias
                .AsNoTracking()
                .FirstAsync(c => c.CategoriaId == id);
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> Post(Categoria categoria)
        {
            await context.AddAsync(categoria);
            
            await context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetCategoria",
                new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPut]
        public async Task<ActionResult<Categoria>> Put(Categoria categoria)
        {
            context.Entry(categoria).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> Delete(int id)
        {
            var categoria = new Categoria { CategoriaId = id };
            
            context.Remove(categoria);

            await context.SaveChangesAsync();
            return Ok(categoria);
        }
    }
}

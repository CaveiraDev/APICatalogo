using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly APICatalogoContext _context;
        private readonly ILogger<CategoriasController> _logger;

        public CategoriasController(APICatalogoContext context , ILogger<CategoriasController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {

            var categorias = _context.Categorias?.Include(p => p.Produtos).ToList();

            if (categorias is null)
            {
                _logger.LogWarning($"Categorias não encontradas");
                return NotFound("Categorias não encontradas");
            }

            return Ok(categorias);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            
               var categorias = _context.Categorias?.ToList();

                if(categorias is null)
                {
                _logger.LogWarning($"Categorias não encontradas");
                return NotFound("Categorias não encontradas");
                }

               return Ok(categorias);
        }


        [HttpGet("{Id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> GetByID(int Id)
        {
            var Categoria = _context.Categorias?.FirstOrDefault(c => c.CategoriaId == Id);
            if(Categoria == null)
            {
                _logger.LogWarning($"Categoria não encontrada...");
                return NotFound("Categora não encontrada...");
            }

            return Categoria;
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            if(categoria is null)
            {
                _logger.LogWarning($"A Categoria informada não está valida");
                return BadRequest("A Categoria informada não está valida");
            }
            _context.Categorias?.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria", 
                new { Id = categoria.CategoriaId }, categoria);


        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if(id != categoria.CategoriaId)
            {
                _logger.LogWarning($"Id da rota não condiz com o categoriaID");
                return BadRequest("Id da rota não condiz com o categoriaID");
            }

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(categoria);
        }


        [HttpDelete("{Id:int}")]
        public ActionResult Delete(int Id)
        {
            var categoria = _context.Categorias?.FirstOrDefault(c => c.CategoriaId==Id);
            if(categoria is null)
            {
                _logger.LogWarning($"Categoria não encontrada...");
                return NotFound("Categoria não encontrada...");
            }

            _context.Categorias?.Remove(categoria);
            _context.SaveChanges();

            return Ok(categoria);
        }
    }
}

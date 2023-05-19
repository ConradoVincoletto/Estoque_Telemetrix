using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.InterfaceCategoria;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Estoque_Telemetrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : Controller
    {
        private readonly ITelemetrix _ITelemetrix;

        public CategoriaController(ITelemetrix _iTelemetrix)
        {
            _ITelemetrix= _iTelemetrix;
        }

        [HttpGet("ListasCategorias")]

        public async Task<IActionResult> ListasCategorias()
        {
            return Json(await _ITelemetrix.ListarCategorias());
        }

        [HttpPost("AdicionarCategoria")]
        public async Task AdicionarCategoria(Categoria categoria)
        {
            await _ICategoria.Add(categoria);
        }

        [HttpGet("ObterCategoriaPorId")]

        public async Task<IActionResult> ObterCategoriaPorId(int Id)
        {
            return Json(await _ICategoria.GetEntityById(Id));
        }

        [HttpPut("AtualizarCategoria")]

        public async Task AtualizarCategoria(Categoria categoria)
        {
            await _ICategoria.Update(categoria);
        }
    }
}

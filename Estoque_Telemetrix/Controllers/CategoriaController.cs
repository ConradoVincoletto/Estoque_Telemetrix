using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.InterfaceCategoria;
using InfraEstrutura.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

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
        public async Task<IActionResult> AdicionarCategoria(Categoria categoria)
        {
            return Json( await _ITelemetrix.AdicionarCategoria(categoria));
        }

        [HttpGet("ObterCategoriaPorId")]

        public async Task<IActionResult> ObterCategoriaPorId(int Id)
        {
            return Json(await _ITelemetrix.ObterCategoriaPorId(Id));
        }

        [HttpPut("AtualizarCategoria")]

        public async Task AtualizarCategoria(Categoria categoria)
        {
            await _ITelemetrix.AtualizarCategoria(categoria);
        }

        [HttpDelete("InativarCategoria")]

        public async Task<IActionResult> InativarCategoria(int Id)
        {
            return Json(await _ITelemetrix.InativarCategoria(Id));
        }
    }
}

using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.InterfaceProduto;
using InfraEstrutura.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Estoque_Telemetrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        
        private readonly ITelemetrix _ITelemetrix;



        public ProdutoController(ITelemetrix iTelemetrix)
        {
            _ITelemetrix = iTelemetrix;
        }

        [HttpGet("ListasProdutos")]
        public async Task<IActionResult> ListasProdutos()
        {
            //return Json(await _IProduto.List());
            return Json(await _ITelemetrix.ListarProdutos());
        }

        [HttpPost("AdicionarProduto")]
        public async Task<IActionResult> AdicionarProduto(Produto produto)
        {
            return Json(await _ITelemetrix.AdicionarProduto(produto));
        }

        [HttpGet("ObterProdutoPorId")]
        public async Task<IActionResult> ObterProdutoPorId(int Id)
        {
            return Json(await _ITelemetrix.ObterProdutoPorId(Id));
        }

        [HttpPut("AtualizarProduto")]
        public async Task AtualizarProduto(Produto produto)
        {
            await _ITelemetrix.AtualizarProduto(produto);
        }

        [HttpDelete("InativarProduto")]

        public async Task<IActionResult> InativarProduto()
        {
            using(var context = new ContextBase())
            {
                var produto = await context.produtos.FindAsync(1);
                context.Remove(produto);
                await context.SaveChangesAsync();
            }
            return Ok("Produto Inativado com sucesso"); 
        }
    }
}

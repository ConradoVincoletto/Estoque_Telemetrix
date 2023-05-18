using Domain.Entities;
using Domain.Interfaces.InterfaceProduto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Estoque_Telemetrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly IProduto _IProduto;

        public ProdutoController(IProduto iProduto)
        {
            _IProduto = iProduto;
        }

        [HttpGet("ListasProdutos")]
        public async Task<IActionResult> ListasProdutos()
        {
            return Json(await _IProduto.List());
        }

        [HttpPost("AdicionarProduto")]
        public async Task AdicionarProduto(Produto produto)
        {
            await _IProduto.Add(produto);
        }

        [HttpGet("ObterProdutoPorId")]
        public async Task<IActionResult> ObterProdutoPorId(int Id)
        {
            return Json(await _IProduto.GetEntityById(Id));
        }

        [HttpPut("AtualizarProduto")]
        public async Task AtualizarProduto(Produto produto)
        {
            await _IProduto.Update(produto);
        }
    }
}

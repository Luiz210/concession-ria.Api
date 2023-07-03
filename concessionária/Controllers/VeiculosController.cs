using concessionária.Models;
using concessionária.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace concessionária.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly VeiculosRepository _veiculosRepository;

        public VeiculosController(IVeiculosRepository veiculosRepository)
        {
            _veiculosRepository = (VeiculosRepository?)veiculosRepository;
        }
        /// <summary>
        /// Lista os Veiculos.
        /// </summary>
        /// <response code="200">Criado com Sucesso</response>
        [HttpGet]
        public async Task<IActionResult> GetVeiculos()
        {
            List<Veiculos> veiculos = await _veiculosRepository.GetVeiculos();
            return Ok(new
            {
                success = true,
                data = veiculos
            });
        }
        /// <summary>
        /// Adiciona um Veiculo.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Retorna o item mais recente criado</response>
        /// <response code="400">se o item for NULO</response>
        [HttpPost]
        public async Task<IActionResult> CreateVeiculos(Veiculos veiculos)
        {
            await _veiculosRepository.CreateVeiculos(veiculos);

            return Ok(new
            {
                success = true,
                data = veiculos
            });
        }
        /// <summary>
        /// Edita um Veiculo.
        /// </summary>
        /// <response code="200">Editado com Sucesso</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVeiculo(int id, Veiculos veiculo)
        {
            await _veiculosRepository.UpdateVeiculo(id, veiculo);

            return Ok(new
            {
                success = true,
                data = veiculo
            });
        }
        /// <summary>
        /// Exclui um Veiculo.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Excluido com Sucesso</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeiculo(int id)
        {
            await _veiculosRepository.DeleteVeiculo(id);

            return Ok(new
            {
                success = true,
                data = id
            });
        }
    }
}

using concessionária.Models;
using concessionária.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace concessionária.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly IVeiculosRepository _veiculosRepository;

        public VeiculosController(IVeiculosRepository veiculosRepository)
        {
            _veiculosRepository = veiculosRepository;
        }

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

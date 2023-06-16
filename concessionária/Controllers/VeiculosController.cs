using concessionária.Context;
using concessionária.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using concessionária.Controllers;
using concessionária.Models;

namespace concessionária.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly ApDbContext _apDbContext;

        public VeiculosController(ApDbContext apDbContext)
        {
            _apDbContext = apDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetVeiculos()
        {
            return Ok(new
            {
                sucess = true,
                data = await _apDbContext.Veiculos.ToListAsync()
            });
        }
        [HttpPost]
        public async Task<IActionResult> CreateVeiculos(concessionária.Models.Veiculos veiculos)
        {
            _apDbContext.Veiculos.Add(veiculos);
            await _apDbContext.SaveChangesAsync();

            return Ok(new
            {
                success = true,
                data = veiculos
            });
        }

    }
}

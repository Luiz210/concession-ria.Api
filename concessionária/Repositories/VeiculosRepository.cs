using concessionária.Context;
using concessionária.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace concessionária.Repositories
{
    public class VeiculosRepository
    {
        private readonly ApDbContext _apDbContext;

        public VeiculosRepository(ApDbContext apDbContext)
        {
            _apDbContext = apDbContext;
        }

        public async Task<List<Veiculos>> GetVeiculos()
        {
            return await _apDbContext.Veiculos.ToListAsync();
        }

        public async Task CreateVeiculos(Veiculos veiculos)
        {
            _apDbContext.Veiculos.Add(veiculos);
            await _apDbContext.SaveChangesAsync();
        }

        public async Task UpdateVeiculo(int id, Veiculos veiculo)
        {
            var existingVeiculo = await _apDbContext.Veiculos.FindAsync(id);
            if (existingVeiculo == null)
            {
                return;
            }

            existingVeiculo.Placa = veiculo.Placa;
            existingVeiculo.Marca = veiculo.Marca;
            existingVeiculo.Preco = veiculo.Preco;
            existingVeiculo.Ano = veiculo.Ano;

            await _apDbContext.SaveChangesAsync();
        }

        public async Task DeleteVeiculo(int id)
        {
            var veiculo = await _apDbContext.Veiculos.FindAsync(id);
            if (veiculo == null)
            {
                return;
            }

            _apDbContext.Veiculos.Remove(veiculo);
            await _apDbContext.SaveChangesAsync();
        }
    }
}

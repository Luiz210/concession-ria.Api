using concessionária.Context;
using concessionária.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace concessionária.Repositories
{
    public class VeiculosRepository : IVeiculosRepository
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

        public async Task<Veiculos> CreateVeiculos(Veiculos veiculos)
        {
            _apDbContext.Veiculos.Add(veiculos);
            await _apDbContext.SaveChangesAsync();
            return veiculos;
        }

        public async Task<Veiculos> UpdateVeiculo(int id, Veiculos veiculo)
        {
            var existingVeiculo = await _apDbContext.Veiculos.FindAsync(id);
            if (existingVeiculo == null)
            {
                return null;
            }

            existingVeiculo.Placa = veiculo.Placa;
            existingVeiculo.Marca = veiculo.Marca;
            existingVeiculo.Preco = veiculo.Preco;
            existingVeiculo.Ano = veiculo.Ano;

            await _apDbContext.SaveChangesAsync();
            return existingVeiculo;
        }

        public async Task<bool> DeleteVeiculo(int id)
        {
            var veiculo = await _apDbContext.Veiculos.FindAsync(id);
            if (veiculo == null)
            {
                return false;
            }

            _apDbContext.Veiculos.Remove(veiculo);
            await _apDbContext.SaveChangesAsync();
            return true;
        }
    }
}

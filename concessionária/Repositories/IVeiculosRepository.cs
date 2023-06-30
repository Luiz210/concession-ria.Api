using concessionária.Models;


namespace concessionária.Repositories
{
    public interface IVeiculosRepository
    {
        Task<List<Veiculos>> GetVeiculos();
        Task<Veiculos> CreateVeiculos(Veiculos veiculos);
        Task<Veiculos> UpdateVeiculo(int id, Veiculos veiculo);
        Task<bool> DeleteVeiculo(int id);
    }
}
using concessionária.Models;

namespace concessionária.Repositories
{
    public interface IVeiculosRepository : ICreateVeiculosRepository, IUpdateVeiculoRepository, IDeleteVeiculoRepository, IGetVeiculosRepository
    {
    }

    public interface ICreateVeiculosRepository
    {
        Task<Veiculos> CreateVeiculos(Veiculos veiculos);
    }

    public interface IUpdateVeiculoRepository
    {
        Task<Veiculos> UpdateVeiculo(int id, Veiculos veiculo);
    }

    public interface IDeleteVeiculoRepository
    {
        Task<bool> DeleteVeiculo(int id);
    }

    public interface IGetVeiculosRepository
    {
        Task<List<Veiculos>> GetVeiculos();
    }
}
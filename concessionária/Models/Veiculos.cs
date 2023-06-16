namespace concessionária.Models
{
    public class Veiculos
    {
        public int Id { get; set; }
        public required string Placa { get; set; }
        public required string Marca { get; set; }
        public float Preco { get; set; }
        public int Ano { get; set; }

    }
}

namespace ValidationLogin.Models
{
    public class Trilha
    {
        public int TrilhaId { get; set; }
        public string Nome { get; set; }
        public string Localizacao { get; set; }
        public double DistanciaKm { get; set; }
        public string Dificuldade { get; set; }
        public DateTime Data { get; set; }
    }
}

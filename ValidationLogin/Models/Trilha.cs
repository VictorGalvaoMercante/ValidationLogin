using System.ComponentModel.DataAnnotations;

namespace ValidationLogin.Models
{
    public class Trilha
    {
        public int TrilhaId { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A localização é obrigatória.")]
        public string Localizacao { get; set; }

        [Required(ErrorMessage = "A distância é obrigatória.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "A distância deve ser maior que zero.")]
        public double DistanciaKm { get; set; }

        [Required(ErrorMessage = "A dificuldade é obrigatória.")]
        public string Dificuldade { get; set; }

        [Required(ErrorMessage = "A data é obrigatória.")]
        public DateTime Data { get; set; }

        [Display(Name = "Imagem da Trilha")]
        public string ImagemUrl { get; set; }
    }
}

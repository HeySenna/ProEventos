using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.Application.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; }
        [Required]
        public string Tema { get; set; }
        [Range(1, 120000)]
        public int QtdPessoas { get; set; }
        public string ImagemURL { get; set; }
        [Required, Phone]
        public string Telefone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public IEnumerable<LoteDto> Lotes { get; set; }
        public IEnumerable<RedeSocialDto> RedesSociais { get; set; }
        public IEnumerable<PalestranteDto> Palestrantes { get; set; }
    }
}
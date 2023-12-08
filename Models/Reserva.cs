using System;
using System.ComponentModel.DataAnnotations;

namespace EventReservationSystem.Models
{
    public class Reserva
    {
        public int ReservaId { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public int EventoId { get; set; }

        [Required]
        public int QuantidadeIngressos { get; set; }

        [Required]
        public string Status { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public DateTime? DataCancelamento { get; set; }

        public Usuario Usuario { get; set; }
        public Evento Evento { get; set; }
    }
}




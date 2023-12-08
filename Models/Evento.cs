using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventReservationSystem.Models
{
    public class Evento
    {
        public int EventoId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public string Local { get; set; }

        public ICollection<Reserva> Reservas { get; set; }
    }
}


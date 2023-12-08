using System;
using System.ComponentModel.DataAnnotations;

namespace EventReservationSystem.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        public ICollection<Reserva> Reservas { get; set; }
    }
}


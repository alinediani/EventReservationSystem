using System;

namespace EventReservationSystem.Queries
{
    public class GetReservasQuery
    {
        public int UsuarioId { get; set; }
        public int EventoId { get; set; } 
        public DateTime? DataMinima { get; set; } 
        public DateTime? DataMaxima { get; set; } 
        public string? Status { get; set; } 
        public int Pagina { get; set; } = 1; 
        public int TamanhoPagina { get; set; } = 10; 
    }
}


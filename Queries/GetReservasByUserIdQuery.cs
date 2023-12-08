namespace EventReservationSystem.Queries
{
    public class GetReservasByUserIdQuery
    {
        public int UsuarioId { get; set; }

        public string OrdenarPor { get; set; }
        public bool OrdemDescendente { get; set; }

        public int Pagina { get; set; } = 1;
        public int TamanhoPagina { get; set; } = 10;
    }
}


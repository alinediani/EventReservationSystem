
namespace EventReservationSystem.Queries
{
    public class GetEventosQuery
    {
        public DateTime? DataMinima { get; set; }
        public DateTime? DataMaxima { get; set; }
        public string Local { get; set; }
        public string NomeContem { get; set; }

        public string OrdenarPor { get; set; }
        public bool OrdemDescendente { get; set; }

        public int Pagina { get; set; } = 1;
        public int TamanhoPagina { get; set; } = 10;
    }
}
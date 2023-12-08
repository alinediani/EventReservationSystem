using EventReservationSystem.Queries;
namespace EventReservationSystem.Commands
{
    public class CreateReservaCommand
    {
        public int EventoId { get; set; }
        public string UsuarioId { get; set; }
        public int QuantidadeIngressos { get; set; }
    }
}

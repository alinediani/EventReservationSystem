using EventReservationSystem.Queries;
namespace EventReservationSystem.Commands
{
    public class UpdateEventoCommand
    {
        public int EventoId { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public string Local { get; set; }
    }
}


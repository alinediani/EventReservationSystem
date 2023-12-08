using EventReservationSystem.Models;
using EventReservationSystem.Queries;
using EventReservationSystem.Commands;
public interface IEventoService
{
    void CriarEvento(CreateEventoCommand command);
    IEnumerable<Evento> ObterEventos(GetEventosQuery query);
    Evento ObterDetalhesEvento(GetEventoByIdQuery query);
    void AtualizarEvento(UpdateEventoCommand command);
    void ExcluirEvento(int eventoId);
}


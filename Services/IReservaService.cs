using System.Collections.Generic;
using EventReservationSystem.Commands;
using EventReservationSystem.Queries;
using EventReservationSystem.Models;

namespace EventReservationSystem.Services
{
    public interface IReservaService
    {
        void CriarReserva(CreateReservaCommand command);
        IEnumerable<Reserva> ObterReservas(GetReservasQuery query);
        Reserva ObterDetalhesReserva(int reservaId);
        void AtualizarReserva(UpdateReservaCommand command);
        void CancelarReserva(int reservaId);
    }
}


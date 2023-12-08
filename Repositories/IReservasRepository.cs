using System;
using System.Collections.Generic;
using EventReservationSystem.Queries;
using EventReservationSystem.Repositories;
using EventReservationSystem.Commands;
using EventReservationSystem.Models;
using EventReservationSystem.Data;

namespace EventReservationSystem.Repositories
{
    public interface IReservasRepository
    {
        void AdicionarReserva(Reserva reserva);
        IEnumerable<Reserva> ObterReservas(GetReservasQuery query);
        Reserva ObterDetalhesReserva(int reservaId);
        void AtualizarReserva(Reserva reserva);
    }
}

// ReservaService.cs
using System;
using System.Collections.Generic;
using System.Linq;
using EventReservationSystem.Commands;
using EventReservationSystem.Models;
using EventReservationSystem.Queries;
using EventReservationSystem.Repositories;
using EventReservationSystem.Services;

public class ReservaService : IReservaService
{
    private readonly IReservasRepository _reservasRepository;

    public ReservaService(IReservasRepository reservasRepository)
    {
        _reservasRepository = reservasRepository ?? throw new ArgumentNullException(nameof(reservasRepository));
    }

    public void CriarReserva(CreateReservaCommand command)
    {
        var novaReserva = new Reserva
        {
            EventoId = command.EventoId,
            UsuarioId = int.Parse(command.UsuarioId),
            QuantidadeIngressos = command.QuantidadeIngressos,
            Status = "Pendente",
            DataCriacao = DateTime.Now
        };


        _reservasRepository.AdicionarReserva(novaReserva);
    }

    public IEnumerable<Reserva> ObterReservas(GetReservasQuery query)
    {
        return _reservasRepository.ObterReservas(query);
    }

    public Reserva ObterDetalhesReserva(int reservaId)
    {
        return _reservasRepository.ObterDetalhesReserva(reservaId);
    }

    public void AtualizarReserva(UpdateReservaCommand command)
    {
        var reservaExistente = _reservasRepository.ObterDetalhesReserva(command.ReservaId);

        reservaExistente.Status = command.NovoStatus;
        reservaExistente.DataAtualizacao = DateTime.Now;

        _reservasRepository.AtualizarReserva(reservaExistente);
    }

    public void CancelarReserva(int reservaId)
    {
        var reservaExistente = _reservasRepository.ObterDetalhesReserva(reservaId);

        reservaExistente.Status = "Cancelada";
        reservaExistente.DataCancelamento = DateTime.Now;

        _reservasRepository.AtualizarReserva(reservaExistente);
    }
}

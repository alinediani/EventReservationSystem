using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EventReservationSystem.Queries;
using EventReservationSystem.Repositories;
using EventReservationSystem.Commands;
using EventReservationSystem.Models;
using EventReservationSystem.Data;

public class ReservasRepository : IReservasRepository
{
    private readonly AppDbContext _dbContext;

    public ReservasRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public void AdicionarReserva(Reserva reserva)
    {
        _dbContext.Reservas.Add(reserva);
        _dbContext.SaveChanges();
    }

    public IEnumerable<Reserva> ObterReservas(GetReservasQuery query)
    {
        var reservas = _dbContext.Reservas.AsQueryable();

        if (query.UsuarioId > 0)
            reservas = reservas.Where(r => r.UsuarioId == query.UsuarioId);

        if (query.EventoId > 0)
            reservas = reservas.Where(r => r.EventoId == query.EventoId);

        if (query.DataMinima.HasValue)
            reservas = reservas.Where(r => r.DataCriacao >= query.DataMinima);

        if (query.DataMaxima.HasValue)
            reservas = reservas.Where(r => r.DataCriacao <= query.DataMaxima);

        if (!string.IsNullOrEmpty(query.Status))
            reservas = reservas.Where(r => r.Status == query.Status);


        return reservas.ToList();
    }

    public Reserva ObterDetalhesReserva(int reservaId)
    {
        return _dbContext.Reservas.Find(reservaId);
    }

    public void AtualizarReserva(Reserva reserva)
    {
        _dbContext.Reservas.Update(reserva);
        _dbContext.SaveChanges();
    }

}

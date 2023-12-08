using EventReservationSystem.Models;
using EventReservationSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EventReservationSystem.Queries;

namespace EventReservationSystem.Repositories
{
    public class EventosRepository : IEventosRepository
    {
        private readonly AppDbContext _dbContext;

        public EventosRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AdicionarEvento(Evento evento)
        {
            _dbContext.Eventos.Add(evento);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Evento> ObterEventos(GetEventosQuery query)
        {
            var eventos = _dbContext.Eventos.AsQueryable();

            if (query.DataMinima.HasValue)
                eventos = eventos.Where(e => e.Data >= query.DataMinima);

            if (query.DataMaxima.HasValue)
                eventos = eventos.Where(e => e.Data <= query.DataMaxima);

            return eventos.ToList();
        }

        public Evento ObterDetalhesEvento(int eventoId)
        {
            return _dbContext.Eventos.Find(eventoId);
        }

        public void AtualizarEvento(Evento evento)
        {
            _dbContext.Eventos.Update(evento);
            _dbContext.SaveChanges();
        }

        public void ExcluirEvento(Evento evento)
        {
            _dbContext.Eventos.Remove(evento);
            _dbContext.SaveChanges();
        }
    }
}


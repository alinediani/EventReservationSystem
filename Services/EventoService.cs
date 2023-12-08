using EventReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EventReservationSystem.Queries;
using EventReservationSystem.Repositories;
using EventReservationSystem.Commands;

public class EventoService : IEventoService
{
    private readonly IEventosRepository _eventosRepository;

    public EventoService(IEventosRepository eventosRepository)
    {
        _eventosRepository = eventosRepository;
    }

    public void CriarEvento(CreateEventoCommand command)
    {
        var novoEvento = new Evento
        {
            Nome = command.Nome,
            Data = command.Data,
            Local = command.Local
        };

        if (string.IsNullOrEmpty(novoEvento.Nome) || novoEvento.Data < DateTime.Now)
        {
            throw new ArgumentException("Nome inválido ou data no passado.");
        }

        _eventosRepository.AdicionarEvento(novoEvento);
    }

    public IEnumerable<Evento> ObterEventos(GetEventosQuery query)
    {
        var eventos = _eventosRepository.ObterEventos(query);

        if (!string.IsNullOrEmpty(query.Local))
        {
            eventos = eventos.Where(e => e.Local == query.Local);
        }

        if (!string.IsNullOrEmpty(query.OrdenarPor))
        {
            eventos = query.OrdemDescendente
                ? eventos.OrderByDescending(e => EF.Property<object>(e, query.OrdenarPor))
                : eventos.OrderBy(e => EF.Property<object>(e, query.OrdenarPor));
        }

        eventos = eventos.Skip((query.Pagina - 1) * query.TamanhoPagina).Take(query.TamanhoPagina);

        return eventos;
    }

    public Evento ObterDetalhesEvento(GetEventoByIdQuery query)
    {
        return _eventosRepository.ObterDetalhesEvento(query.EventoId);
    }

    public void AtualizarEvento(UpdateEventoCommand command)
    {
        var eventoExistente = _eventosRepository.ObterDetalhesEvento(command.EventoId);

        if (eventoExistente == null)
        {
            throw new InvalidOperationException("Evento não encontrado.");
        }

        if (string.IsNullOrEmpty(command.Nome) || command.Data < DateTime.Now)
        {
            throw new ArgumentException("Nome inválido ou data no passado.");
        }

        eventoExistente.Nome = command.Nome;
        eventoExistente.Data = command.Data;
        eventoExistente.Local = command.Local;

        _eventosRepository.AtualizarEvento(eventoExistente);
    }

    public void ExcluirEvento(int eventoId)
    {
        var eventoExistente = _eventosRepository.ObterDetalhesEvento(eventoId);

        if (eventoExistente == null)
        {
            throw new InvalidOperationException("Evento não encontrado.");
        }

        _eventosRepository.ExcluirEvento(eventoExistente);
    }
}


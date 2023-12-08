using EventReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EventReservationSystem.Queries;
public interface IEventosRepository
{
    void AdicionarEvento(Evento evento);
    IEnumerable<Evento> ObterEventos(GetEventosQuery query);
    Evento ObterDetalhesEvento(int eventoId);
    void AtualizarEvento(Evento evento);
    void ExcluirEvento(Evento evento);
}

using Microsoft.AspNetCore.Mvc;
using EventReservationSystem.Queries;
using EventReservationSystem.Commands;
[ApiController]
[Route("api/eventos")]
public class EventosController : ControllerBase
{
    private readonly IEventoService _eventoService;

    public EventosController(IEventoService eventoService)
    {
        _eventoService = eventoService;
    }

    [HttpPost("CriarEvento")]
    public IActionResult CriarEvento([FromBody] CreateEventoCommand command)
    {
        try
        {
            _eventoService.CriarEvento(command);
            return Ok("Evento criado com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao criar evento: {ex.Message}");
        }
    }

    [HttpGet("ObterEventos")]
    public IActionResult ObterEventos([FromQuery] GetEventosQuery query)
    {
        try
        {
            var eventos = _eventoService.ObterEventos(query);
            return Ok(eventos);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao obter eventos: {ex.Message}");
        }
    }

    [HttpGet("{id}/ObterDetalhesEvento")]
    public IActionResult ObterDetalhesEvento(int id)
    {
        try
        {
            var query = new GetEventoByIdQuery { EventoId = id };
            var evento = _eventoService.ObterDetalhesEvento(query);
            return Ok(evento);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao obter detalhes do evento: {ex.Message}");
        }
    }

    [HttpPut("{id}/AtualizarEvento")]
    public IActionResult AtualizarEvento(int id, [FromBody] UpdateEventoCommand command)
    {
        try
        {
            command.EventoId = id;
            _eventoService.AtualizarEvento(command);
            return Ok("Evento atualizado com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao atualizar evento: {ex.Message}");
        }
    }

    [HttpDelete("{id}/ExcluirEvento")]
    public IActionResult ExcluirEvento(int id)
    {
        try
        {
            _eventoService.ExcluirEvento(id);
            return Ok("Evento excluído com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao excluir evento: {ex.Message}");
        }
    }
}


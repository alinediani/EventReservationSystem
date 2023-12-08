using Microsoft.AspNetCore.Mvc;
using EventReservationSystem.Commands;
using EventReservationSystem.Services;
using EventReservationSystem.Queries;

[ApiController]
[Route("api/reservas")]
public class ReservasController : ControllerBase
{
    private readonly IReservaService _reservaService;

    public ReservasController(IReservaService reservaService)
    {
        _reservaService = reservaService;
    }

    [HttpPost("CriarReserva")]
    public IActionResult CriarReserva([FromBody] CreateReservaCommand command)
    {
        try
        {
            _reservaService.CriarReserva(command);
            return Ok("Reserva criada com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao criar reserva: {ex.Message}");
        }
    }

    [HttpGet("{userId:int}/ObterReservas")]
    public IActionResult ObterReservas(int userId)
    {
        try
        {
            var query = new GetReservasQuery
            {
                UsuarioId = userId
            };

            var reservas = _reservaService.ObterReservas(query);
            return Ok(reservas);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao obter reservas: {ex.Message}");
        }
    }


    [HttpPut("{id}/AtualizarReserva")]
    public IActionResult AtualizarReserva(int id, [FromBody] UpdateReservaCommand command)
    {
        try
        {
            command.ReservaId = id;
            _reservaService.AtualizarReserva(command);
            return Ok("Reserva atualizada com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao atualizar reserva: {ex.Message}");
        }
    }

    [HttpDelete("{id}/CancelarReserva")]
    public IActionResult CancelarReserva(int id)
    {
        try
        {
            _reservaService.CancelarReserva(id);
            return Ok("Reserva cancelada com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao cancelar reserva: {ex.Message}");
        }
    }
}


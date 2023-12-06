using Event_System.Core.Entity.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Event_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ILogger<TicketsController> _logger;

        public TicketsController(IMediator mediator , ILogger<TicketsController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetTickets")]
        public async Task<IActionResult> GetEventAsync()
        {
            
            var userId = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            getTicketDto g = new getTicketDto(userId);

            var tickets = await _mediator.Send(g);
            if (tickets != null)
            {
                return Ok(tickets);
            }
            else
            {
                return NotFound("No tickets found.");
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("BookTicket")]
        public async Task<ActionResult> BookTicketAsync(int eventId)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            _logger.LogInformation("****************  " + userId);
            TicketDto1 e = new TicketDto1(userId, eventId);

            var response = await _mediator.Send(e, cancellationToken: HttpContext.RequestAborted);

            return Ok(new { Message = response });
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("CancelTicket")]
        public async Task<ActionResult> CancelTicketAsync(int eventId)
        {

            var userId = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            _logger.LogInformation("****************  " + User);
            TicketDto e = new TicketDto(userId, eventId);

            var response = await _mediator.Send(e, cancellationToken: HttpContext.RequestAborted);
            _logger.LogError("/*/*/*/*/*/**/  " + response);
            return Ok(new { Message = response });
        }

    }
}

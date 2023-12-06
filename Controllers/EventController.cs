using AutoMapper;
using Event_System.Application;
using Event_System.Core.Entity.DTOs;
using Event_System.Core.Entity.Models;
using Event_System.Persistance.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Security.Claims;

namespace Event_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ILogger<EventController> _logger;
        private readonly IStringLocalizer<EventController> _localizer;
        public EventController(IMediator mediator
            , ILogger<EventController> logger,
            IStringLocalizer<EventController> localizer)
        {
           
            _mediator = mediator;
            _logger = logger;
            _localizer = localizer;
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("CreateEvent")]
        public async Task<ActionResult> CreateEventAsync([FromBody] EventDto command)
        {
           
            var userId = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            _logger.LogInformation("*******************  " + userId);
            EventDto1 e = new EventDto1(userId , command);
           
            var responce = await _mediator.Send(e ,cancellationToken: HttpContext.RequestAborted);
            var localizedString = _localizer[responce];
            _logger.LogError("*---***--*-*- " + localizedString + "    "+ responce);
            return Ok(new { Message = localizedString });
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("UpdateEvent")]
        public async Task<ActionResult> UpdateEventAsync([FromBody] EventDto command , int eventId)
        {

            var userId = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            _logger.LogInformation("*******************  " + userId);
            EventUpdate e = new EventUpdate(userId, eventId, command);


            var responce = await _mediator.Send(e, cancellationToken: HttpContext.RequestAborted);

            return Ok(new { Message = responce });
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("DeleteEvent")]
        public async Task<ActionResult> DeleteEventAsync( int eventId)
        {

            var userId = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            _logger.LogInformation("*******************  " + userId);
            EventDelete e = new EventDelete(userId, eventId);


            var responce = await _mediator.Send(e, cancellationToken: HttpContext.RequestAborted);

            return Ok(new { Message = responce });
        }

        
        [HttpGet("GetEvent")]
        public async Task<IActionResult> GetEventAsync()
        {
           
                var query = new GetEventsQuery();

                var events = await _mediator.Send(query);
                if (events != null)
                {
                    return Ok(events);
                }
                else
                {
                    return NotFound("No events found.");
                }
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using EventManager.Interfaces;
using EventManager.Models;

namespace EventManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventController(IEventService eventService) : ControllerBase
{
    private readonly IEventService _eventService = eventService;

    [HttpGet]
    public ApiResult<List<Event>> GetAllEvents()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id:Guid}")]
    public ApiResult<Event> GetEventById([FromRoute] Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPost("{event:Event}")]
    public ApiResult PostEvent([FromBody] Event newEvent)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{id:Guid}, {event:Event}")]
    public ApiResult PutEvent([FromRoute] Guid id, [FromBody] Event updatedEvent)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id:Guid}")]
    public ApiResult Delete([FromRoute] Guid id)
    {
        throw new NotImplementedException();
    }
}

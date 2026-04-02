using EventManager.Interfaces;
using EventManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EventManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventController(IEventService eventService) : ControllerBase
{
    private readonly IEventService _eventService = eventService;

    [HttpGet]
    public ApiResult<IReadOnlyCollection<Event>> GetAllEvents()
    {
        var events = _eventService.GetAllEvents();
        return new ApiResult<IReadOnlyCollection<Event>>
        {
            Data = events,
            Success = true,
            StatusCode = HttpStatusCode.OK,
            Message = $"Получено событий: {events.Count}",
            DateTime = DateTime.Now,
        };
    }

    [HttpGet("{id:int}")]
    public ApiResult<Event?> GetEventById([FromRoute] int id)
    {
        var eventById = _eventService.GetEvent(id);
        return new ApiResult<Event?>
        {
            Data = eventById,
            Success = eventById != null,
            StatusCode = eventById != null ? HttpStatusCode.OK : HttpStatusCode.BadRequest,
            Message = eventById != null ? $"Получено событие с id: {id}" : $"Не найдено событие с id: {id}",
            DateTime = DateTime.Now,
        };
    }

    [HttpPost]
    public ApiResult PostEvent([FromBody] Event newEvent)
    {
        var isPosted = _eventService.CreateEvent(newEvent);
        return new ApiResult
        {
            Success = isPosted,
            StatusCode = isPosted ? HttpStatusCode.Created : HttpStatusCode.BadRequest,
            Message = isPosted ? $"Создано событие с id: {newEvent.Id}" : $"Не удалось создать событие с id: {newEvent.Id}",
            DateTime = DateTime.Now,
        };
    }

    [HttpPut("{id:int}")]
    public ApiResult PutEvent([FromRoute] int id, [FromBody] Event updatedEvent)
    {
        var isUpdated = _eventService.UpdateEvent(id, updatedEvent);
        return new ApiResult
        {
            Success = isUpdated,
            StatusCode = isUpdated ? HttpStatusCode.Created : HttpStatusCode.BadRequest,
            Message = isUpdated ? $"Обновлено событие с id: {id}" : $"Не найдено событие с id: {id}",
            DateTime = DateTime.Now,
        };
    }

    [HttpDelete("{id:int}")]
    public ApiResult Delete([FromRoute] int id)
    {
        var isDeleted = _eventService.DeleteEvent(id);
        return new ApiResult
        {
            Success = isDeleted,
            StatusCode = isDeleted ? HttpStatusCode.NoContent : HttpStatusCode.BadRequest,
            Message = isDeleted ? $"Удалено событие с id: {id}" : $"Не найдено событие с id: {id}",
            DateTime = DateTime.Now,
        };
    }
}

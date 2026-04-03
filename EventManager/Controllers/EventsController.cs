using EventManager.Interfaces;
using EventManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EventManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController(IEventService eventService) : ControllerBase
{
    private readonly IEventService _eventService = eventService;

    [HttpGet]
    public ApiResult<IReadOnlyCollection<EventDto>> GetAllEvents()
    {
        var events = _eventService.GetAllEvents();
        return new ApiResult<IReadOnlyCollection<EventDto>>
        {
            Data = events,
            Success = true,
            StatusCode = HttpStatusCode.OK,
            Message = $"Получено событий: {events.Count}",
            DateTime = DateTime.Now,
        };
    }

    [HttpGet("{id:int}")]
    public ApiResult<EventDto?> GetEventById([FromRoute] int id)
    {
        var eventById = _eventService.GetEvent(id);
        return new ApiResult<EventDto?>
        {
            Data = eventById,
            Success = eventById != null,
            StatusCode = eventById != null ? HttpStatusCode.OK : HttpStatusCode.BadRequest,
            Message = eventById != null ? $"Получено событие с id: {id}" : $"Не найдено событие с id: {id}",
            DateTime = DateTime.Now,
        };
    }

    [HttpPost]
    public ApiResult PostEvent([FromBody] EventDto newEvent)
    {
        var isPosted = _eventService.CreateEvent(newEvent);
        return new ApiResult
        {
            Success = isPosted,
            StatusCode = isPosted ? HttpStatusCode.Created : HttpStatusCode.NotFound,
            Message = isPosted ? $"Создано событие с id: {newEvent.Id}" : $"Не удалось создать событие с id: {newEvent.Id}",
            DateTime = DateTime.Now,
        };
    }

    [HttpPut("{id:int}")]
    public ApiResult PutEvent([FromRoute] int id, [FromBody] EventDto updatedEvent)
    {
        var isUpdated = _eventService.UpdateEvent(id, updatedEvent);
        return new ApiResult
        {
            Success = isUpdated,
            StatusCode = isUpdated ? HttpStatusCode.OK : HttpStatusCode.NotFound,
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
            StatusCode = isDeleted ? HttpStatusCode.NoContent : HttpStatusCode.NotFound,
            Message = isDeleted ? $"Удалено событие с id: {id}" : $"Не найдено событие с id: {id}",
            DateTime = DateTime.Now,
        };
    }
}

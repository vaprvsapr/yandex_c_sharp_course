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
        return new ApiResult<IReadOnlyCollection<Event>>
        {
            Data = _eventService.GetAllEvents(),
            Success = true,
            StatusCode = HttpStatusCode.OK,
            Message = "Получаем все события",
            DateTime = DateTime.Now,
        };
    }

    [HttpGet("{id:Guid}")]
    public ApiResult<Event?> GetEventById([FromRoute] Guid id)
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

    [HttpPut("{id:Guid}")]
    public ApiResult PutEvent([FromRoute] Guid id, [FromBody] Event updatedEvent)
    {
        var isUpdated = _eventService.UpdateEvent(updatedEvent);
        return new ApiResult
        {
            Success = isUpdated,
            StatusCode = isUpdated ? HttpStatusCode.Created : HttpStatusCode.BadRequest,
            Message = isUpdated ? $"Обновлено событие с id: {id}" : $"Не найдено событие с id: {id}",
            DateTime = DateTime.Now,
        };
    }

    [HttpDelete("{id:Guid}")]
    public ApiResult Delete([FromRoute] Guid id)
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

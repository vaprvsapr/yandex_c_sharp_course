using EventManager.Interfaces;
using EventManager.Models;

namespace EventManager.Services;

public class EventService(IEventRepository eventRepository) : IEventService
{
    private readonly IEventRepository _eventRepository = eventRepository;

    public bool CreateEvent(EventDto newEventDto)
    {
        return _eventRepository.Add(EventDto.ToEvent(newEventDto));
    }

    public bool DeleteEvent(int id)
    {
        return _eventRepository.Delete(id);
    }

    public IReadOnlyCollection<EventDto> GetAllEvents()
    {
        return _eventRepository.GetAll().Select(EventDto.ToEventDto).ToList().AsReadOnly();
    }

    public EventDto? GetEvent(int id)
    {
        var eventById = _eventRepository.GetById(id);
        return eventById == null ? null : EventDto.ToEventDto(eventById);
    }

    public bool UpdateEvent(int id, EventDto updatedEventDto)
    {
        return _eventRepository.Update(id, EventDto.ToEvent(updatedEventDto));
    }
}

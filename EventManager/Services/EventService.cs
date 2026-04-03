using EventManager.Interfaces;
using EventManager.Models;

namespace EventManager.Services;

public class EventService(IEventRepository eventRepository) : IEventService
{
    private readonly IEventRepository _eventRepository = eventRepository;

    public bool CreateEvent(EventDto newEventDto)
    {
        return _eventRepository.Add(newEventDto.ToEvent());
    }

    public bool DeleteEvent(int id)
    {
        return _eventRepository.Delete(id);
    }

    public IReadOnlyCollection<EventDto> GetAllEvents()
    {
        return _eventRepository.GetAll().Select(e => e.ToEventDto()).ToList().AsReadOnly();
    }

    public EventDto? GetEvent(int id)
    {
        return _eventRepository.GetById(id)?.ToEventDto();
    }

    public bool UpdateEvent(int id, EventDto updatedEventDto)
    {
        return _eventRepository.Update(id, updatedEventDto.ToEvent());
    }
}

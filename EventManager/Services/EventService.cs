using EventManager.Interfaces;
using EventManager.Models;

namespace EventManager.Services;

public class EventService(IEventRepository eventRepository) : IEventService
{
    private readonly IEventRepository _eventRepository = eventRepository;

    public bool CreateEvent(Event newEvent)
    {
        return _eventRepository.Add(newEvent);
    }

    public bool DeleteEvent(Guid id)
    {
        return _eventRepository.Delete(id);
    }

    public IReadOnlyCollection<Event> GetAllEvents()
    {
        return _eventRepository.GetAll();
    }

    public Event? GetEvent(Guid id)
    {
        return _eventRepository.GetById(id);
    }

    public bool UpdateEvent(Event updatedEvent)
    {
        return _eventRepository.Update(updatedEvent);
    }
}

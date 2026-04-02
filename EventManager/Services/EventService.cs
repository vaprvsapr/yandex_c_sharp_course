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

    public bool DeleteEvent(int id)
    {
        return _eventRepository.Delete(id);
    }

    public IReadOnlyCollection<Event> GetAllEvents()
    {
        return _eventRepository.GetAll();
    }

    public Event? GetEvent(int id)
    {
        return _eventRepository.GetById(id);
    }

    public bool UpdateEvent(int id, Event updatedEvent)
    {
        return _eventRepository.Update(id, updatedEvent);
    }
}

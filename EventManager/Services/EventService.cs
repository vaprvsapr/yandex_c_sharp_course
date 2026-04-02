using EventManager.Interfaces;
using EventManager.Models;

namespace EventManager.Services;

public class EventService(IEventRepository eventRepository) : IEventService
{
    private readonly IEventRepository _eventRepository = eventRepository;
    public void CreateEvent(Event newEvent)
    {
        _eventRepository.Add(newEvent);
    }

    public IReadOnlyCollection<Event> GetAllEvents()
    {
        return _eventRepository.GetAll();
    }

    public Event? GetEvent(Guid id)
    {
        return _eventRepository.GetById(id);
    }

    public void UpdateEvent(Event updatedEvent)
    {
        _eventRepository.Update(updatedEvent);
    }
}

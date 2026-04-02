using EventManager.Models;

namespace EventManager.Interfaces;

public interface IEventService
{
    public Event? GetEvent(int id);
    public IReadOnlyCollection<Event> GetAllEvents();
    public bool CreateEvent(Event newEvent);
    public bool UpdateEvent(int id, Event updatedEvent);
    public bool DeleteEvent(int id);
}

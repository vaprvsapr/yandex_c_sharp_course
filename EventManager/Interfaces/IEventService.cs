using EventManager.Models;

namespace EventManager.Interfaces;

public interface IEventService
{
    public Event? GetEvent(Guid id);
    public IReadOnlyCollection<Event> GetAllEvents();
    public bool CreateEvent(Event newEvent);
    public bool UpdateEvent(Event updatedEvent);
    public bool DeleteEvent(Guid id);
}

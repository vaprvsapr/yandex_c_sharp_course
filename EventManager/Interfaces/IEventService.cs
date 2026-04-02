using EventManager.Models;

namespace EventManager.Interfaces;

public interface IEventService
{
    public Event? GetEvent(Guid id);
    public IReadOnlyCollection<Event> GetAllEvents();
    public void CreateEvent(Event newEvent);
    public void UpdateEvent(Event updatedEvent);
}

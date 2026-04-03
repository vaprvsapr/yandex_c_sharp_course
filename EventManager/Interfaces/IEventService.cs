using EventManager.Models;

namespace EventManager.Interfaces;

public interface IEventService
{
    public EventDto? GetEvent(int id);
    public IReadOnlyCollection<EventDto> GetAllEvents();
    public bool CreateEvent(EventDto newEvent);
    public bool UpdateEvent(int id, EventDto updatedEvent);
    public bool DeleteEvent(int id);
}

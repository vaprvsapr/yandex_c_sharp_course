using EventManager.Interfaces;
using EventManager.Models;

namespace EventManager.Data;

public class EventRepository : IEventRepository
{
    private readonly List<Event> _events = [];
    public bool Add(Event newEvent)
    {
        var existingEvent = _events.FirstOrDefault(e => e.Id == newEvent.Id);
        if (existingEvent == null)
        {
            _events.Add(newEvent);
            return true;
        }
        return false;
    }

    public bool Delete(int id)
    {
        var existingEvent = _events.FirstOrDefault(e => e.Id == id);
        if (existingEvent != null)
        {
            _events.Remove(existingEvent);
            return true;
        }
        return false;
    }

    public IReadOnlyCollection<Event> GetAll()
    {
        return _events.AsReadOnly();
    }

    public Event? GetById(int id)
    {
        return _events.FirstOrDefault(e => e.Id == id);
    }

    public bool Update(int id, Event updatedEvent)
    {
        var existingEvent = _events.FirstOrDefault(e => e.Id == id);
        if (existingEvent != null)
        {
            existingEvent = updatedEvent;
            return true;
        }
        return false;
    }
}

using EventManager.Interfaces;
using EventManager.Models;

namespace EventManager.Data;

public class EventRepository : IEventRepository
{
    private readonly List<Event> _events = [];
    public void Add(Event newEvent)
    {
        // Добавить проверку на уникальность ID, если необходимо
        _events.Add(newEvent);
    }

    public void Delete(Guid id)
    {
        var eventToDelete = _events.FirstOrDefault(e => e.Id == id);
        if (eventToDelete != null)
            _events.Remove(eventToDelete);
    }

    public IReadOnlyCollection<Event> GetAll()
    {
        return _events.AsReadOnly();
    }

    public Event? GetById(Guid id)
    {
        return _events.FirstOrDefault(e => e.Id == id);
    }

    public void Update(Event updatedEvent)
    {
        throw new NotImplementedException();
    }
}

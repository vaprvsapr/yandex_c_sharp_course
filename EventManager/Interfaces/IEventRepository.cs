using EventManager.Models;

namespace EventManager.Interfaces;

public interface IEventRepository
{
    Event? GetById(Guid id);
    IReadOnlyCollection<Event> GetAll();
    void Add(Event newEvent);
    void Update(Event updatedEvent);
}

using EventManager.Models;

namespace EventManager.Interfaces;

public interface IEventRepository
{
    Event? GetById(Guid id);
    IReadOnlyCollection<Event> GetAll();
    bool Add(Event newEvent);
    bool Update(Event updatedEvent);
    bool Delete(Guid id);
}

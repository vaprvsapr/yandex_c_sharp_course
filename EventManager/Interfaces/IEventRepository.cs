using EventManager.Models;

namespace EventManager.Interfaces;

public interface IEventRepository
{
    Event? GetById(int id);
    IReadOnlyCollection<Event> GetAll();
    bool Add(Event newEvent);
    bool Update(int id,Event updatedEvent);
    bool Delete(int id);
}

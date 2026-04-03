using System.ComponentModel.DataAnnotations;

namespace EventManager.Models;

public class EventDto : IValidatableObject
{
    [Required(ErrorMessage = "id обязателен для заполнения.")]
    public required int Id { get; init; }

    [Required(ErrorMessage = "title обязателен для заполнения.")]
    public required string Title { get; set; }
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "startAt обязателен для заполнения.")]
    public required DateTime StartAt { get; set; }

    [Required(ErrorMessage = "endAt обязателен для заполнения.")]
    public required DateTime EndAt { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (EndAt <= StartAt)
            yield return new ValidationResult(
                "Время окончания события должно быть позже времени начала.",
                [nameof(EndAt)]
            );
    }

    public static Event ToEvent(EventDto eventDto)
    {
        return new Event
        {
            Id = eventDto.Id,
            Title = eventDto.Title,
            Description = eventDto.Description,
            StartAt = eventDto.StartAt,
            EndAt = eventDto.EndAt
        };
    }

    public static EventDto ToEventDto(Event eventModel)
    {
        return new EventDto
        {
            Id = eventModel.Id,
            Title = eventModel.Title,
            Description = eventModel.Description,
            StartAt = eventModel.StartAt,
            EndAt = eventModel.EndAt
        };
    }
}

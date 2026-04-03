using Microsoft.AspNetCore.Mvc.ModelBinding;
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

    public Event ToEvent()
    {         
        return new Event
        {
            Id = this.Id,
            Title = this.Title,
            Description = this.Description,
            StartAt = this.StartAt,
            EndAt = this.EndAt
        };
    }
}

public class Event
{
    public required int Id { get; init; }
    public required string Title { get; set; }
    public string Description { get; set; } = string.Empty;
    public required DateTime StartAt { get; set; }
    public required DateTime EndAt { get; set; }

    public EventDto ToEventDto()
    {
        return new EventDto
        {
            Id = this.Id,
            Title = this.Title,
            Description = this.Description,
            StartAt = this.StartAt,
            EndAt = this.EndAt
        };
    }
}

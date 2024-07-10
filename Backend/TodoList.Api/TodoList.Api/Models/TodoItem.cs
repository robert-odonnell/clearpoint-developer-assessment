using System.ComponentModel.DataAnnotations;

namespace TodoList.Api.Models;

public class TodoItem
{
    public long? Id { get; set; }

    [Required]
    [StringLength(500)]
    public string? Description { get; set; }

    public bool IsComplete { get; set; }
}
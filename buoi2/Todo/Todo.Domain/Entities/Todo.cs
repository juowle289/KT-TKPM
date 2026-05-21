using System;
using System.Collections.Generic;

// namespace Todo.Infrastructure;

namespace Todo.Domain.Entities;

public partial class Todo
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public bool? IsCompleted { get; set; }
}

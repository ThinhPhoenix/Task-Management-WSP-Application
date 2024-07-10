using System;
using System.Collections.Generic;

namespace TaskManagementRepo.Models;

public partial class Task
{
    public string TaskId { get; set; } = null!;

    public string? UserId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? DueDate { get; set; }

    public byte? Priority { get; set; }

    public byte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Priority? PriorityNavigation { get; set; }

    public virtual Status? StatusNavigation { get; set; }

    public virtual User? User { get; set; }
}

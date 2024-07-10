using System;
using System.Collections.Generic;

namespace TaskManagementRepo.Models;

public partial class Priority
{
    public byte Id { get; set; }

    public string? Ptype { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}

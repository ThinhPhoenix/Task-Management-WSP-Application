using System;
using System.Collections.Generic;

namespace TaskManagementRepo.Models;

public partial class Status
{
    public byte Id { get; set; }

    public string? Stype { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}

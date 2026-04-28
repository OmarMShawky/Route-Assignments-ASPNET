using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventHub;

public class Organizer
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    public string? CompanyName { get; set; }
    public bool IsVerified { get; set; }
    public OrganizerProfile Profile { get; set; } = null!;
    public ICollection<Event> Events { get; set; } = new List<Event>();
}

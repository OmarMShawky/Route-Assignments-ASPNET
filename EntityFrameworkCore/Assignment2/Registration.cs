using System;
using System.Collections.Generic;
using System.Text;

namespace EventHub;

public class Registration
{
    public int AttendeeId { get; set; } // Composite primary keys
    public int EventId { get; set; } // Composite primary keys
    public string? Note { get; set; }
    public DateTime RegisteredAt { get; set; }
    public Attendee Attendee { get; set; } = null!;
    public Event Event { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.Text;

namespace EventHub;

public class Event
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int MaxAttendees { get; set; }
    public int? ParentEventId { get; set; }
    public Event? ParentEvent { get; set; }
    public ICollection<Event> Sessions { get; set; }
    public int OrganizerId { get; set; }
    public Organizer Organizer { get; set; } = null!;
    public ICollection<Registration> Registrations { get; set; }
}

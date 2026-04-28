using System;
using System.Collections.Generic;
using System.Text;

namespace EventHub;

public class Badge
{
    public Guid Id { get; set; }
    public int BadgeNumber { get; set; }
    public DateTime IssuedAt { get; set; }
    public BadgeTier Tier { get; set; }
    public int AttendeeId { get; set; }
    public Attendee Attendee { get; set; } = null!;
}

public enum BadgeTier
{
    Standard = 0,
    VIP = 1
}
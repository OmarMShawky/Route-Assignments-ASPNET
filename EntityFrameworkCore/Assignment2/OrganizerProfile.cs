using System;
using System.Collections.Generic;
using System.Text;

namespace EventHub;

public class OrganizerProfile
{
    public int Id { get; set; }
    public string Biography { get; set; } = null!;
    public string WebsiteUrl { get; set; } = null!;
    public string LogoUrl { get; set; } = null!;
    public int OrganizerId { get; set; }
    public Organizer Organizer { get; set; } = null!;
}

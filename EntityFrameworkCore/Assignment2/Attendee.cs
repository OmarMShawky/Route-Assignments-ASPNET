using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Text;

namespace EventHub;

[Table("Attendees")]
public class Attendee
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string FullName { get; set; } = null!;

    [MaxLength(50)]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [MaxLength(200)]
    [Column("AddressStreet")]
    public string Street { get; set; } = null!;

    [MaxLength(100)]
    [Column("AddressCity")]
    public string City { get; set; } = null!;

    [MaxLength(100)]
    [Column("AddressCountry")]
    public string Country { get; set; } = null!;

    [MaxLength(20)]
    [Column("AddressPostalCode")]
    public string PostalCode { get; set; } = null!;

    public Badge? Badge { get; set; }

    public ICollection<Registration> Registrations { get; set; }
}

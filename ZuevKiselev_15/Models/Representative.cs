using System;
using System.Collections.Generic;

namespace ZuevKiselev_15.Models;

public partial class Representative
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string TelephoneNumber { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();
}

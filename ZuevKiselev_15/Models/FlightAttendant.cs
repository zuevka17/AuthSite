using System;
using System.Collections.Generic;

namespace ZuevKiselev_15.Models;

public partial class FlightAttendant
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int TelephoneNumber { get; set; }

    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();
}

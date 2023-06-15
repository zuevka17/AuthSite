using System;
using System.Collections.Generic;

namespace ZuevKiselev_15.Models;

public partial class Pilot
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int TelephoneNumber { get; set; }

    public int HoursInAir { get; set; }

    public string Adress { get; set; } = null!;

    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();
}

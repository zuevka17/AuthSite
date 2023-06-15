using System;
using System.Collections.Generic;

namespace ZuevKiselev_15.Models;

public partial class Airplane
{
    public int Id { get; set; }

    public string Model { get; set; } = null!;

    public string Location { get; set; } = null!;

    public int NumberOfSeats { get; set; }

    public int LoadCapacity { get; set; }

    public sbyte ReadyForDeparture { get; set; }

    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();
}

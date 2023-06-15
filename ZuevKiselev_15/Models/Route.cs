using System;
using System.Collections.Generic;

namespace ZuevKiselev_15.Models;

public partial class Route
{
    public int Id { get; set; }

    public string RouteType { get; set; } = null!;

    public virtual ICollection<FlightPlan> FlightPlans { get; set; } = new List<FlightPlan>();

    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();
}

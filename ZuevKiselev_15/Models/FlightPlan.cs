using System;
using System.Collections.Generic;

namespace ZuevKiselev_15.Models;

public partial class FlightPlan
{
    public int Id { get; set; }

    public string DepartureAirfield { get; set; } = null!;

    public string DepartureTime { get; set; } = null!;

    public string DestinationAirfield { get; set; } = null!;

    public string ArrivalTime { get; set; } = null!;

    public string FlightDuration { get; set; } = null!;

    public string AlternateAirfield { get; set; } = null!;

    public int RoutesId { get; set; }

    public virtual Route Routes { get; set; } = null!;
}

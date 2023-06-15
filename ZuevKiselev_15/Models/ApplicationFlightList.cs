using System;
using System.Collections.Generic;

namespace ZuevKiselev_15.Models;

public partial class ApplicationFlightList
{
    public int Id { get; set; }

    public int EstimatedProfit { get; set; }

    public int ApplicationsId { get; set; }

    public int FlightsId { get; set; }

    public virtual Application Applications { get; set; } = null!;

    public virtual Flight Flights { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace ZuevKiselev_15.Models;

public partial class Flight
{
    public int Id { get; set; }

    public int RepresentativesId { get; set; }

    public int PilotsId { get; set; }

    public int AirplanesId { get; set; }

    public int FlightAttendantsId { get; set; }

    public int RoutesId { get; set; }

    public virtual Airplane Airplanes { get; set; } = null!;

    public virtual ICollection<ApplicationFlightList> ApplicationFlightLists { get; set; } = new List<ApplicationFlightList>();

    public virtual FlightAttendant FlightAttendants { get; set; } = null!;

    public virtual Pilot Pilots { get; set; } = null!;

    public virtual Representative Representatives { get; set; } = null!;

    public virtual Route Routes { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace ZuevKiselev_15.Models;

public partial class Application
{
    public int Id { get; set; }

    public string Destination { get; set; } = null!;

    public string PlaceOfDeparture { get; set; } = null!;

    public int ClientsId { get; set; }

    public int RepresentativesId { get; set; }

    public virtual ICollection<ApplicationFlightList> ApplicationFlightLists { get; set; } = new List<ApplicationFlightList>();

    public virtual ICollection<Cargo> Cargos { get; set; } = new List<Cargo>();

    public virtual Client Clients { get; set; } = null!;

    public virtual ICollection<Passanger> Passangers { get; set; } = new List<Passanger>();

    public virtual Representative Representatives { get; set; } = null!;
}

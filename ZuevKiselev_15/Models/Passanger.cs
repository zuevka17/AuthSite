using System;
using System.Collections.Generic;

namespace ZuevKiselev_15.Models;

public partial class Passanger
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int PlaceInAirplane { get; set; }

    public int ApplicationsId { get; set; }

    public virtual Application Applications { get; set; } = null!;
}

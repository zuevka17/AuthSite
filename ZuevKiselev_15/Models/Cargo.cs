using System;
using System.Collections.Generic;

namespace ZuevKiselev_15.Models;

public partial class Cargo
{
    public int Id { get; set; }

    public int Weight { get; set; }

    public string Name { get; set; } = null!;

    public string Number { get; set; } = null!;

    public int ApplicationId { get; set; }

    public virtual Application Application { get; set; } = null!;
}

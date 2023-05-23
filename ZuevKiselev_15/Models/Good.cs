using System;
using System.Collections.Generic;

namespace ZuevKiselev_15.Models;

public partial class Good
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Price { get; set; } = null!;

    public int UserId { get; set; }

    public int Amount { get; set; }

    public virtual User User { get; set; } = null!;
}

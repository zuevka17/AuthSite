using System;
using System.Collections.Generic;

namespace ZuevKiselev_15.Models;

public partial class Client
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int TelephoneNumber { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}

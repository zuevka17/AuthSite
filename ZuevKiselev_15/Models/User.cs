﻿using System;
using System.Collections.Generic;

namespace ZuevKiselev_15.Models;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Good> Goods { get; set; } = new List<Good>();
}

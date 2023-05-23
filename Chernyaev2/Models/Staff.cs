using System;
using System.Collections.Generic;

namespace Chernyaev2.Models;

public partial class Staff
{
    public int Id { get; set; }

    public string? Fio { get; set; }

    public string? Unit { get; set; }

    public string? Depart { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }
}

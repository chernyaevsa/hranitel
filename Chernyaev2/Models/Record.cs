using System;
using System.Collections.Generic;

namespace Chernyaev2.Models;

public partial class Record
{
    public int Id { get; set; }

    public string? Note { get; set; }

    public string? Visit { get; set; }
}

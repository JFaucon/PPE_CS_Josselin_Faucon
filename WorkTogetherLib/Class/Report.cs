using System;
using System.Collections.Generic;

namespace WorkTogetherLib.Class;

public partial class Report
{
    public int Id { get; set; }

    public int UserrId { get; set; }

    public string Subject { get; set; } = null!;

    public string Object { get; set; } = null!;

    public virtual User Userr { get; set; } = null!;
}

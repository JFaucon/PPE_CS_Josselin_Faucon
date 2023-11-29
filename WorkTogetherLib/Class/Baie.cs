using System;
using System.Collections.Generic;

namespace WorkTogetherLib.Class;

public partial class Baie
{
    public int Id { get; set; }

    public int NbSpot { get; set; }

    public string Code { get; set; } = null!;

    public virtual ICollection<Unite> Unites { get; set; } = new List<Unite>();
}

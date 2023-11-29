using System;
using System.Collections.Generic;

namespace WorkTogetherLib.Class;

public partial class Unite
{
    public int Id { get; set; }

    public int BaieId { get; set; }

    public int? ReservationId { get; set; }

    public string NumSpot { get; set; } = null!;

    public bool Available { get; set; }

    public virtual Baie Baie { get; set; } = null!;

    public virtual Reservation? Reservation { get; set; }
}

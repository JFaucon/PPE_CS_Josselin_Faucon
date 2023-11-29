using System;
using System.Collections.Generic;

namespace WorkTogetherLib.Class;

public partial class Reservation
{
    public int Id { get; set; }

    public int UserrId { get; set; }

    public int ForfaitId { get; set; }

    public string Number { get; set; } = null!;

    public DateOnly BeginDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int Quantity { get; set; }

    public bool Renewable { get; set; }

    public virtual Forfait Forfait { get; set; } = null!;

    public virtual ICollection<Unite> Unites { get; set; } = new List<Unite>();

    public virtual User Userr { get; set; } = null!;
}

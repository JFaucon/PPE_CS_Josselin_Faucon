using System;
using System.Collections.Generic;

namespace WorkTogetherLib.Class;

public partial class Forfait
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public int NbSlot { get; set; }

    public int Discount { get; set; }

    public int NbMonth { get; set; }

    public string ImgPath { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WorkTogetherLib.Class;

public partial class Forfait : IEditableObject
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public int NbSlot { get; set; }

    public int Discount { get; set; }

    public int NbMonth { get; set; }

    public string ImgPath { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public void BeginEdit()
    {
        
    }

    public void CancelEdit()
    {
        
    }

    public void EndEdit()
    {
        using WorkTogetherContext context = new WorkTogetherContext();
        {
            context.Entry(this).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}

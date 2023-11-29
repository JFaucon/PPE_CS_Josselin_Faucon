using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WorkTogetherLib.Class;

public partial class User : IEditableObject
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    /// <summary>
    /// (DC2Type:json)
    /// </summary>
    public string Roles { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Discr { get; set; } = null!;

    public string? ProfileImage { get; set; }

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    private User backupCopy;

    public void BeginEdit()
    {
        // Sauvegarde une copie des données originales
        backupCopy = MemberwiseClone() as User;
    }

    public void CancelEdit()
    {
        // Annule les modifications en restaurant les données originales
        if (backupCopy != null)
        {
            Id = backupCopy.Id;
            Email = backupCopy.Email;
            FirstName = backupCopy.FirstName;
            LastName = backupCopy.LastName;
            Roles = backupCopy.Roles;
            Discr = backupCopy.Discr;
        }
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

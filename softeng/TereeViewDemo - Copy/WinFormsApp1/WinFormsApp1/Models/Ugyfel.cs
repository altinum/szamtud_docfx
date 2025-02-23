using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WinFormsApp1.Models;

[Table("UGYFEL")]
[Index("Email", Name = "UQ_UGYFEL_Email", IsUnique = true)]
public partial class Ugyfel
{
    [Key]
    [Column("UgyfelID")]
    public int UgyfelId { get; set; }

    [StringLength(100)]
    public string Nev { get; set; } = null!;

    [StringLength(255)]
    public string Email { get; set; } = null!;

    [StringLength(20)]
    public string? Telefonszam { get; set; }

    [Column("LakcimID")]
    public int? LakcimId { get; set; }

    [ForeignKey("LakcimId")]
    [InverseProperty("Ugyfel")]
    public virtual Cim? Lakcim { get; set; }

    [InverseProperty("Ugyfel")]
    public virtual ICollection<Rendeles> Rendeles { get; set; } = new List<Rendeles>();
}

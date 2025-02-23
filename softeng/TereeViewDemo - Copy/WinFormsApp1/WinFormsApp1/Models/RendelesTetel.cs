using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WinFormsApp1.Models;

[Table("RENDELES_TETEL")]
public partial class RendelesTetel
{
    [Key]
    [Column("TetelID")]
    public int TetelId { get; set; }

    [Column("RendelesID")]
    public int RendelesId { get; set; }

    [Column("TermekID")]
    public int TermekId { get; set; }

    public int Mennyiseg { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal EgysegAr { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal Afa { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal NettoAr { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal BruttoAr { get; set; }

    [ForeignKey("RendelesId")]
    [InverseProperty("RendelesTetel")]
    public virtual Rendeles Rendeles { get; set; } = null!;

    [ForeignKey("TermekId")]
    [InverseProperty("RendelesTetel")]
    public virtual Termek Termek { get; set; } = null!;
}

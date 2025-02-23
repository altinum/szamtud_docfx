using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WinFormsApp1.Models;

[Table("RENDELES")]
public partial class Rendeles
{
    [Key]
    [Column("RendelesID")]
    public int RendelesId { get; set; }

    [Column("UgyfelID")]
    public int UgyfelId { get; set; }

    [Column("SzallitasiCimID")]
    public int SzallitasiCimId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RendelesDatum { get; set; }

    [StringLength(20)]
    public string Statusz { get; set; } = null!;

    [Column(TypeName = "decimal(5, 2)")]
    public decimal Kedvezmeny { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Vegosszeg { get; set; }

    [InverseProperty("Rendeles")]
    public virtual ICollection<RendelesTetel> RendelesTetel { get; set; } = new List<RendelesTetel>();

    [ForeignKey("SzallitasiCimId")]
    [InverseProperty("Rendeles")]
    public virtual Cim SzallitasiCim { get; set; } = null!;

    [ForeignKey("UgyfelId")]
    [InverseProperty("Rendeles")]
    public virtual Ugyfel Ugyfel { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WinFormsApp1.Models;

[Table("CIM")]
public partial class Cim
{
    [Key]
    [Column("CimID")]
    public int CimId { get; set; }

    [StringLength(100)]
    public string Utca { get; set; } = null!;

    [StringLength(20)]
    public string Hazszam { get; set; } = null!;

    [StringLength(50)]
    public string Varos { get; set; } = null!;

    [StringLength(10)]
    public string Iranyitoszam { get; set; } = null!;

    [StringLength(50)]
    public string Orszag { get; set; } = null!;

    [InverseProperty("SzallitasiCim")]
    public virtual ICollection<Rendeles> Rendeles { get; set; } = new List<Rendeles>();

    [InverseProperty("Lakcim")]
    public virtual ICollection<Ugyfel> Ugyfel { get; set; } = new List<Ugyfel>();
}

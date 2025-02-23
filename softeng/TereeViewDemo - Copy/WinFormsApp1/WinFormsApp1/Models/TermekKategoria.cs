using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WinFormsApp1.Models;

[Table("TERMEK_KATEGORIA")]
public partial class TermekKategoria
{
    [Key]
    [Column("KategoriaID")]
    public int KategoriaId { get; set; }

    [StringLength(50)]
    public string Nev { get; set; } = null!;

    public string? Leiras { get; set; }

    [Column("SzuloKategoriaID")]
    public int? SzuloKategoriaId { get; set; }

    [InverseProperty("SzuloKategoria")]
    public virtual ICollection<TermekKategoria> InverseSzuloKategoria { get; set; } = new List<TermekKategoria>();

    [ForeignKey("SzuloKategoriaId")]
    [InverseProperty("InverseSzuloKategoria")]
    public virtual TermekKategoria? SzuloKategoria { get; set; }

    [InverseProperty("Kategoria")]
    public virtual ICollection<Termek> Termek { get; set; } = new List<Termek>();
}

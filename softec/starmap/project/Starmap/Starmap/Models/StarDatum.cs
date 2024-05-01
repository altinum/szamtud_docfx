using System;
using System.Collections.Generic;

namespace Starmap.Models;

public partial class StarDatum
{
    public int Hip { get; set; }

    public double Magnitude { get; set; }

    public double? RaDegrees { get; set; }

    public double? DecDegrees { get; set; }

    public double? ParallaxMas { get; set; }

    public double? RaMasPerYear { get; set; }

    public double? DecMasPerYear { get; set; }

    public double? RaHours { get; set; }

    public double? EpochYear { get; set; }

    public double X { get; set; }

    public double Y { get; set; }
}

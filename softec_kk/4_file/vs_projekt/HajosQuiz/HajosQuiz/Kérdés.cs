using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HajosQuiz
{
internal class Kérdés
{
    public string KérdésSzöveg { get; set; }

    public string Válasz1 { get; set; }

    public string Válasz2 { get; set; }

    public string Válasz3 { get; set; }

    public string URL { get; set; }

    public int HelyesVálasz { get; set; }

    public int HelyesVálaszokSzáma { get; set; }

}
}

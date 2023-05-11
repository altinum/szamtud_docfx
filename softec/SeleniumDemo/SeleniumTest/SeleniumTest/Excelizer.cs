using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest
{
    public class Excelizer
    {
        // Adunk egy tulajdonságot az osztálynak, ez lesz az elérési út
        public string Path { get; set; }
        // Konstruktorba ezt bekérjük és be is állítjuk
        public Excelizer(string path)
        {
            this.Path = path;
        }
        // Ez a metódus fogja legenerálni az excel táblát, az alapján az órákat tartalmazó lista alapján, amit kap
        public void CreateTimeTable(List<UniClass> classes)
        {
            // Az EPPLus szeretne pénzt kérni, ha üzleti fejlesztésben van használva a munkájuk, ezért a
            // licenszt beállíthatjuk, nem üzletire
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Ami a using blokkba van, az a using blokkból kilépve tisztességesen be lesz csukva
            using (var package = new ExcelPackage())
            {
                // A csomaggal létrehozunk egy munkafüzetet, ebben fogunk dolgozni
                var worksheet = package.Workbook.Worksheets.Add("Órarend");

                int startHour = 8; // Innen indítjuk a napot
                int endHour = 21; // Itt fejezzük be

                // Felcímkézzük a sorokat, hogy hány órát jelentenek
                for (int hour = startHour; hour <= endHour; hour++)
                {
                    for (int minute = 0; minute < 60; minute += 10)
                    {
                        int rowIndex = 2 + ((hour - startHour) * 6) + (minute / 10);
                        worksheet.Cells[rowIndex, 1].Value = $"{hour:D2}:{minute:D2}";
                    }
                }
                // Felcímkézzük az oszlopokat is, minden másodikat, hogy szebb legyen és ki tudjunk hagyni egy picit
                // a napok között
                worksheet.Cells[1, 2].Value = "Hétfő";
                worksheet.Cells[1, 4].Value = "Kedd";
                worksheet.Cells[1, 6].Value = "Szerda";
                worksheet.Cells[1, 8].Value = "Csütörtök";
                worksheet.Cells[1, 10].Value = "Péntek";

                //Az első oszlop magasságát 15 pontról 30-ra állítjuk
                worksheet.Row(1).Height = 30;
                //Kiválasztjuk az első sort és félkövérre állítjuk
                var font = worksheet.Cells["1:1"].Style.Font;
                font.Bold = true;
                // Feltöltjük a munkafüzetet az órákkal
                for (int i = 0; i < classes.Count; i++)
                {
                    UniClass uniClass = classes[i];

                    // Kiszámoljuk a kezdő és záró sor indexet az idő alapján
                    int startRowIndex = 2 + (((uniClass.StartTime.Hours - startHour) * 6) + (uniClass.StartTime.Minutes / 10));
                    int endRowIndex = 2 + (((uniClass.EndTime.Hours - startHour) * 6) + (uniClass.EndTime.Minutes / 10));

                    // Beírjuk a szöveget a cellába
                    worksheet.Cells[startRowIndex, 2 + uniClass.DayOfWeek * 2].Value = uniClass.Title;

                    // Beállítjuk a sortörést
                    worksheet.Cells[startRowIndex, 2 + uniClass.DayOfWeek * 2].Style.WrapText = true;

                    // Átméretezzük az oszlopokat (itt más mértékegységet használunk).
                    // Az oszlop amiben az óra van az 12 széles és 2 szünet lesz mellette
                    worksheet.Column(2 + uniClass.DayOfWeek * 2).Width = 12;
                    worksheet.Column(2 + uniClass.DayOfWeek * 2 + 1).Width = 2;

                    // Beállítjuk, hogy a szöveg a tetejére húzzon
                    worksheet.Cells[startRowIndex, 2 + uniClass.DayOfWeek * 2].Style.VerticalAlignment = ExcelVerticalAlignment.Top;


                    // Kitöltjük tankönyves nyomtatós stílussal a cellát, természetesen Fuchsiára
                    var fill = worksheet.Cells[startRowIndex, 2 + uniClass.DayOfWeek * 2].Style.Fill;
                    fill.PatternType = ExcelFillStyle.LightTrellis;
                    fill.BackgroundColor.SetColor(Color.Fuchsia);

                    // Összeolvasztjuk az alatta lévő cellákkal, amíg tart az óra
                    worksheet.Cells[startRowIndex, 2 + uniClass.DayOfWeek * 2, endRowIndex, 2 + uniClass.DayOfWeek * 2].Merge = true;

                }

                // Elmentjük a munkafüzetet Orarend.xlsx néven
                // Itt a System.IO előtagra szükség van, mert az osztályszintű elérési út is Path!
                package.SaveAs(new FileInfo(System.IO.Path.Combine(this.Path, "Orarend.xlsx")));

            }
        }
    }
}

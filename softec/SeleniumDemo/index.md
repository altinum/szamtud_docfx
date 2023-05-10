# Third Party Package-ek használata

A mai gyakorlat rendhagyó lesz több szempontból is. Egy saját projektet kell létrehozni legalább az egyik mintaprojektben is használt csomag felhasználásával. Az óra első 10-15 percében érdemes megismerkedni a két csomaggal, a `Selenium`-mal és `EPPlus`-szal a mintaprojekten keresztül, majd az onnan ellesett építőkockák felhasználásával létrehozni egy saját alklamazást.

A modern fejlesztői környezet részévé vált a `ChatGPT`, ezért most a használata nemcsak, hogy engedélyezett, hanem kötelező. Sokkal gyorsabban el lehet érni vele a kívánt eredményt, mint a hivatalos dokumentáció böngészésével. Azonban itt fontos megjegyezni, hogy "A nagy erő, nagy felelősséggel jár." (Pókember). Nem lehet teljesen rábízni magunkat az AI-ra, mert könnyen el tud vinni minket vakvágányra és előfordul, hogy túlbonyolít és halucinál dolgokat.

## Tippek a ChatGPT használatához
1. Kontextus: Adjuk át minél jobban, hogy mik az elvárásaink és milyen környezetben vagyunk, hagyjunk minél kevesebb dolgot a képzelőerőnek
2. Tegyünk fel jól strukturált kérdéseket és ha feladatot adunk, legyünk precízek
3. Kérdezzünk bátran és kérdezzünk vissza, ha valamit nem értünk, kiemelve a kérdéses részeket
4. Ha változtatunk a kódon miután átvettük akkor a következő kérdésnél adjuk oda a modellnek, hogy jó kóddal dolgozzon
5. Ha valami nem jó, pontosítsunk
6. Használjunk minél fejlettebb modellt

## Néhány példa a mintaprojekt készítéséből
(!Stepper)

(!Step)[Excel generáló sablonja]
# [Prompt](#tab/focus)
Complete this function: public void CreateTimeTable(List<UniClass> classes)
        {

        } use EPPlus, put the classes[i].Title into the cells, based on the classes[i].StartTime and Endtime, which are timespans. The timetable's upper left corner is in cell b2. One cell should be 10 minutes, so if a class starts at 8:00 it should be in the second row, and for every ten minutes until 9:30 for instance you should merge a cell below.
# [Válasz](#tab/entire)
  Here is a simple implementation of your CreateTimeTable function using EPPlus. Please note that this is a basic implementation, and you may need to adjust it to fit your specific needs:
```csharp
using OfficeOpenXml;

public void CreateTimeTable(List<UniClass> classes)
{
    using (var package = new ExcelPackage())
    {
        var worksheet = package.Workbook.Worksheets.Add("TimeTable");

        int startHour = 8; // Starting hour of the timetable
        int endHour = 20; // Ending hour of the timetable

        // Write time labels on the left side
        for (int hour = startHour; hour <= endHour; hour++)
        {
            for (int minute = 0; minute < 60; minute += 10)
            {
                int rowIndex = 1 + ((hour - startHour) * 6) + (minute / 10);
                worksheet.Cells[rowIndex, 1].Value = $"{hour:D2}:{minute:D2}";
            }
        }

        // Write classes
        for (int i = 0; i < classes.Count; i++)
        {
            UniClass uniClass = classes[i];

            // Calculate row index for start and end times
            int startRowIndex = 1 + ((uniClass.StartTime.Hours - startHour) * 6) + (uniClass.StartTime.Minutes / 10);
            int endRowIndex = 1 + ((uniClass.EndTime.Hours - startHour) * 6) + (uniClass.EndTime.Minutes / 10);

            // Write class title into cells and merge them
            worksheet.Cells[startRowIndex, 2, endRowIndex, 2].Merge = true;
            worksheet.Cells[startRowIndex, 2].Value = uniClass.Title;
        }

        // Save to a file
        package.SaveAs(new FileInfo("TimeTable.xlsx"));
    }
}
```
                                          In this code, we first write the time labels on the left side of the timetable. Then, for each class, we calculate the row indices for the start and end times, write the class title into the corresponding cells, and merge them. Finally, we save the workbook to a file.

Please note that this code assumes that the StartTime and EndTime of each UniClass are TimeSpan instances representing the start and end times of the class on the same day, and that the start and end times are rounded to the nearest 10 minutes. If this is not the case, you may need to adjust the code.

Also note that this code does not handle conflicts, i.e., it does not check if a cell is already occupied by another class. If you need to handle conflicts, you would need to add additional logic for that.
***
(!EndStep)
(!Step)[Mi a nuget package neve?]
# [Prompt](#tab/focus)
give me the nuget I need to use
# [Válasz](#tab/entire)
To use EPPlus in your .NET project, you need to install the EPPlus NuGet package. You can install it through the NuGet Package Manager in Visual Studio, or by using the following command in the Package Manager Console:
```bash
Install-Package EPPlus
```
***
(!EndStep)
(!Step)[Hogy vágjam ki a html-ből a lényeges információt?]
                                          
(!EndStep)
(!EndStepper)

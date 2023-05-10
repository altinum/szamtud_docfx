# Third Party Package-ek használata

A mai gyakorlat rendhagyó lesz több szempontból is. Egy saját projektet kell létrehozni legalább az egyik mintaprojektben is használt csomag felhasználásával. Az óra első 10-15 percében érdemes megismerkedni a két csomaggal, a `Selenium`-mal és `EPPlus`-szal a mintaprojekten keresztül, majd az onnan ellesett építőkockák felhasználásával érdemes létrehozni a saját alklamazást.

A programnyelvek igazi erejét az ökoszisztéma gerincét az elérhető csomagok/könyvtárak alkotják. A programozás tulajdonképpen probléma megoldás több szinten, minél absztraktabb módon. Nem kell gépi kódot írnunk, mert vannak magas szintű programnyelvek, nem kell minden dolgot feltalálni a programnyelvekben sem, mert vannak alap osztályok és funkciók és erre épül rá a harmadik féltől származó könyvtár/csomag. Miért vesződjünk azzal, hogy egy objektumot `JSON`-ná konvertáljunk, ha ezt már valaki nagy fáradozással megtette helyettünk?

A modern fejlesztői környezet részévé vált a `ChatGPT`, ezért most a használata nemcsak hogy engedélyezett, de feladat is. Sokkal gyorsabban el lehet érni vele a kívánt eredményt, mint a hivatalos dokumentáció böngészésével. Azonban itt fontos megjegyezni, hogy "A nagy erő, nagy felelősséggel jár." (Pókember). Nem lehet teljesen rábízni magunkat az AI-ra, mert könnyen el tud vinni minket vakvágányra és előfordul, hogy túlbonyolít és halucinál dolgokat.

A mintaprojektet ezen a linken éritek el:
https://github.com/bodnarbalazs/SeleniumDemo

## Röviden a mintaprojektről
A mintaprojekt két könyvtárat használ, a Seleniummal böngészőt tudunk vezérelni és az EPPlussal pedig Excel táblákat lehet kezelni.
Az alkalmazás felmegy a neptunra, bejelentkezik, megnézi az órarendet és az órarend alapján csinál egy excel fájlt, az órarendünkről.

Három osztályt használunk, a `Scraper.cs`-be száműztük azt a kódot, ami a böngésző irányításért felel, az `Excelizer.cs`-be raktuk azt, ami az Excel generálást végzi és van egy `UniClass` nevű osztályunk, ami az óránknak a modellje.

>[!Note]
>Azért lett UniClass, mert a class az egy foglalt kifejezés a C#-ban és példányosításnál nem lehetne neki egyszerűen a class nevet adni és félrevezető lehet, de ha bármilyen foglalt kifejezés elé írunk egy @-t, akkor használhatjuk változó névként.

(!Hint) Klónozd le a repository-t és próbáld ki a mintaalkalmazást [!Kérdezd meg a ChatGPT-t hogyan kell!]

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
                                          
(!Step)[Hogyan vágjam ki a HTML-ből a lényeges információt?]

# [Prompt](#tab/focus)
From an element like this, grab me the starting hour:minute and finishing hour:minute and the text from Ora] 
                                          
                                          <div style="WIDTH:100%;top:0px;left:0%;" title="Idő:2023 Május 8 (Hétfő) 08:00 -  09:30
Esemény:[Óra] Folyamat-menedzsment (INIR041NMBB)  - E01   Minden hét (Dr. Szabó Zoltán;Előre Rögzített Videós 50%;Dr. Őri Dóra) ()
Hely:Nem definiált" class="chip chip0 "><div class="dhdV" style="display:none">0$$0$Mon May 08 2023 09:30:00 GMT+0200 (Central European Summer Time)$693158734$false$$0$[object Object]$0$Mon May 08 2023 08:00:00 GMT+0200 (Central European Summer Time)$2$[Óra] Folyamat-menedzsment (INIR041NMBB)  - E01   Minden hét (Dr. Szabó Zoltán;Előre Rögzített Videós 50%;Dr. Őri Dóra) ()$$</div><div style="BORDER-BOTTOM-COLOR:#9BB6E6" class="ct">&nbsp;</div><dl style="BORDER-BOTTOM-COLOR:#9BB6E6; BACKGROUND-COLOR:#B3C5E3; BORDER-TOP-COLOR: #9BB6E6; HEIGHT: 77px; BORDER-RIGHT-COLOR:#9BB6E6; BORDER-LEFT-COLOR:#9BB6E6;"><dt style="BACKGROUND-COLOR:#9BB6E6">08:00 - 09:30 <i class="cic cic-tmr">&nbsp;</i></dt><dd><span>[Óra] Folyamat-menedzsment (INIR041NMBB)  - E01   Minden hét (Dr. Szabó Zoltán;Előre Rögzített Videós 50%;Dr. Őri Dóra) ()</span></dd><div class="resizer" style="display:none"><div class="rszr_icon">&nbsp;</div></div></dl><div style="BORDER-BOTTOM-COLOR:#9BB6E6; BACKGROUND-COLOR:#B3C5E3; BORDER-TOP-COLOR: #9BB6E6; BORDER-RIGHT-COLOR: #9BB6E6; BORDER-LEFT-COLOR:#9BB6E6" class="cb1">&nbsp;</div><div style="BORDER-BOTTOM-COLOR:#9BB6E6; BORDER-TOP-COLOR:#9BB6E6; BORDER-RIGHT-COLOR:#9BB6E6; BORDER-LEFT-COLOR:#9BB6E6" class="cb2">&nbsp;</div></div>
>[!Note]
>Ide eredetileg egy ronda html-kódot másoltam, de mivel a Neptun olyan zseniálisan van megírva, ezért a stílus is benne van a html-ben és az oldal lerendereli
# [Válasz](#tab/entire)
        
The provided HTML snippet is quite complex, but it looks like the information you're looking for ("starting hour:minute", "finishing hour:minute", and "text from Ora") is included in the title attribute of the div with class chip, as well as inside the dt and dd tags.

In Selenium WebDriver with C#, you can extract this information as follows:
```csharp
// Assuming you have the element stored in a variable 'element'
string title = element.GetAttribute("title");

// Split the title string to extract the desired parts
string[] titleParts = title.Split('\n');

// The time range is in the first line, split by ' -  '
string[] timeRange = titleParts[0].Split(" -  ");
string startingTime = timeRange[0].Substring(timeRange[0].LastIndexOf(" ") + 1);  // extract the time after the last space
string finishingTime = timeRange[1];

// The text from Ora is in the second line, inside square brackets
string textFromOra = titleParts[1].Substring(titleParts[1].IndexOf('[') + 1, titleParts[1].IndexOf(']') - titleParts[1].IndexOf('[') - 1);

Console.WriteLine($"Starting time: {startingTime}");
Console.WriteLine($"Finishing time: {finishingTime}");
Console.WriteLine($"Text from Ora: {textFromOra}");

```
This code first retrieves the title attribute from the div element, then splits it into lines. It further splits the first line to get the time range, and extracts the "starting hour:minute" and "finishing hour:minute" from it. Finally, it extracts the "text from Ora" from the second line. This is based on the assumption that the title attribute's format is consistent across elements.

Please note that the "text from Ora" extraction assumes there's only one pair of square brackets in the line. If there can be multiple pairs, you'll need to adjust the code accordingly.
***
        
(!EndStep)
        
(!EndStepper)
        
## Selenium

(!Hint) Kérdezd meg a ChatGPT-t, hogy mi az a Selenium! [!A Selenium egy olyan eszköz vagy keretrendszer, amely lehetővé teszi a webes alkalmazások automatizált tesztelését és a böngészőalapú műveletek programozását. A Selenium lehetővé teszi a felhasználók számára, hogy felvegyenek teszteket, amelyek az egyes felhasználói eseteket szimulálják, és ellenőrzik, hogy az alkalmazás működik-e a tervezett módon. A Selenium támogatja a legnépszerűbb böngészőket, mint például a Google Chrome, a Mozilla Firefox és az Internet Explorer, és lehetővé teszi a felhasználók számára, hogy automatizáltan töltsenek ki űrlapokat, kattintsanak gombokra, navigáljanak az oldalak között, és még sok más dolgot tegyenek. A Selenium nagyon hasznos lehet a webfejlesztők és tesztelők számára, akik hatékonyabb és megbízhatóbb teszteket szeretnének végrehajtani, valamint a webes alkalmazások fejlesztői számára, akik könnyedén hozzáadhatják a Selenium támogatását az alkalmazásaikhoz.]
        
## EPPlus

(!Hint) Kérdezd meg mire jó az EPPlus! [!Az EPPlus egy .NET-ben írt nyílt forráskódú könyvtár, amely lehetővé teszi a Microsoft Excel fájlok olvasását és írását. Az EPPlus alkalmas Excel-fájlok létrehozására, módosítására, olvasására és mentésére is, és támogatja a legtöbb Excel-fájl formátumot. Az EPPlus-nal a fejlesztők programozói módon kezelhetik az Excel-fájlokat, így lehetőségük van arra, hogy a programozás révén generálják az Excel-táblázatokat vagy azok tartalmát. Az EPPlus további előnye, hogy nagyon hatékonyan kezeli a nagy adathalmazokat, és támogatja a diagramok, táblázatok, képek és más elemek beillesztését az Excel-fájlokba. Az EPPlus így kiválóan alkalmas olyan alkalmazások fejlesztésére, amelyek az Excel adathalmazok kezelésére épülnek, és lehetőséget kívánnak adni az adatok vizualizálására és elemzésére.]

                                                                                                      
                                                                                                      
                                                                                                      
                                                                                                      
                                                                                                      
                                                                                                      
                                                                                                      
                                                                                                      
                                                                                                      
                                                                                                      
                                                                                                      
                                                                                                      
                                                                                                      
                                                                                                      
                                                                                                      

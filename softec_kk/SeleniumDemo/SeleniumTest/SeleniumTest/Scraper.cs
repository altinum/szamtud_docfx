using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;


namespace SeleniumTest
{
    public class Scraper
    {
        // Ez a neptununk url-je ez nem fog változni, nyugodtan iderakhatjuk
        private static string _url = @"https://neptun3r.web.uni-corvinus.hu/Hallgatoi/login.aspx";

        // Ez a függvény fogja megszerezni nekünk az óráinkat, de ehhez szüksége van a felhasználónevünkre és jelszavunkra, amit a Form1-ből szerzünk.
        public static List<UniClass> ScrapeClasses(string username, string password)
        {
            // Minden böngészőre máshogy kell konfigurálni a Selenium motort, it a Chrome-ot használjuk
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();

            // Megnyitjuk a neptunt
            driver.Navigate().GoToUrl(_url);

            // Ez a két elem az, ahova beírnánk a neptun kódot és jelszót. A driver-rel meg tudjuk találni a weboldalon az elemeket a szellemes By segítségével.
            // Itt a felhasználó nevet fogadó inputot a neve alapján választjuk ki, a jelszavasat pedig az id-ja alapján.
            var usernameField = driver.FindElement(By.Name("user"));
            var passwordField = driver.FindElement(By.Id("pwd"));

            // Beíratjuk a motorral a felhasználónevet és jelszót
            usernameField.SendKeys(username);
            passwordField.SendKeys(password);

            // Példányosítunk egy osztályt, aminek az a feladata, hogy megváratja a motort, maximum addig, amennyi a konstruktor második argumentuma
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Itt például addig váratjuk, amíg nem talál egy btnSubmit id-val rendelkező elemet.
            // A nyilas dolog benne egy lambda kifejezés, ami tulajdonképpen egy rövidített függvény
            // Lesz róla szó bővebben a következő félévben.
            var loginButton = wait.Until(driver => driver.FindElement(By.Id("btnSubmit")));

            // Rákattintunk a gombra
            loginButton.Click();

            // Itt a Tanulmányok linket szeretnénk berakni a studiesLink változóba, aminek nem mondjuk meg előre, hogy micsoda
            // mert a jobb oldalából következik ez például lehet bármilyen olyan osztály példánya, ami teljesíti az
            // IWebElement interfész kritériumait és lehet null, mert van mögötte kérdőjel
            // A wait addig váratja a motort, amíg olyan eredményt kap, ami nem null
            var studiesLink = wait.Until(driver =>
            {
                try
                {
                    // Itt XPath alapján választjuk ki az elemet, ebben egyerre benne van a típusa és most a szövege is.
                    return driver.FindElement(By.XPath("//li[contains(text(), 'Tanulmányok')]"));
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });
            // Létrehozunk egy olyan osztályt, amivel felhasználói mozdulatokat tudunk emulálni.
            Actions actions = new Actions(driver);
            // Rákattintunk vele a Tanulmányok linkre
            actions.MoveToElement(studiesLink).Perform();

            var scheduleLink = driver.FindElement(By.Id("mb1_Tanulmanyok_Órarend"));
            actions.MoveToElement(scheduleLink).Perform();
            // Rákattintunk az Órarend linkre
            scheduleLink.Click();

            // Megvárjuk míg betölt (az, hogy maga a tábla létezik még nem jelenti azt, hogy a tartalma is fel van töltve)
            wait.Until(driver => driver.FindElement(By.Id("c_common_timetable_tabOrarend_body")));
            // Altatjuk a függvényt 3 másodpercig, hogy biztosan betöltsön az is, ami benne van
            Thread.Sleep(3000);

            // Megfogjuk az oszlop elemet, amiben vannak az órák
            var days = driver.FindElements(By.ClassName("tg-col"));

            List<UniClass> classes = new List<UniClass>();
            int d = 0;

            // Végigmegyünk minden oszlopon
            foreach (var day in days)
            {
                // A kék óra buborékok mind chip osztállyal rendelkeznek, azzal választjuk őket ki
                var classesInDay = day.FindElements(By.ClassName("chip"));

                foreach (IWebElement classElement in classesInDay)
                {
                    // Kiválasztjuk az aktuális óra elemének a title attribútumát
                    string title = classElement.GetAttribute("title");

                    // Felvágjuk a sortörések mentén
                    string[] titleParts = title.Split('\n');

                    // Az időt ' - ' mentén választjuk le
                    string[] timeRange = titleParts[0].Split(" - ");
                    string startingTime = timeRange[0].Substring(timeRange[0].LastIndexOf(" ") + 1);
                    string finishingTime = timeRange[1].Split("\r")[0].Trim();

                    // Az lesz a szöveg, ami az [Óra] rész után van
                    string classTitle = titleParts[1].Split("[Óra] ")[1];

                    // Konstruktor nélkül létrehozunk egy új UniClass-t a szerzett paraméterekkel
                    classes.Add(new UniClass
                    {
                        // A TimeSpan osztály hasonló, mint a DateTime, de ez időintervallumot jelöl.
                        // Itt odaadjuk a ParseExact függvényének a feldolgozott stringünket és súgunk neki, hogy milyen formában van
                        StartTime = TimeSpan.ParseExact(startingTime, "h\\:mm", null),
                        EndTime = TimeSpan.ParseExact(finishingTime, "h\\:mm", null),
                        Title = classTitle,
                        DayOfWeek = d
                    });

                }

                // Növeljük a d (nap) számlálónkat, később innen fogjuk tudni, hogy melyik nap van az óra
                d++;
            }

            // Becsukjuk a Seleniumot, hogy ne maradjon nyitva a fekete ablak.
            driver.Close();
            driver.Quit();
            return classes;
        }
    }
}








# Jegyzetek előadásra


## Példák dátumkezelésre

``` csharp
string TimeZoneId = "Central European Standard Time";

// Specify the CET time zone
TimeZoneInfo cetZone = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneId);

// Get the current time in the CET time zone 
DateTime cetTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cetZone);
```



```	c#
// Get the current date and time
DateTime currentDateTime = DateTime.Now;

// Get midnight from the current date
DateTime midnight = currentDateTime.Date;
```

GhetGPT kérdések:

- Melyik napok estek ki Gergely pápa naptárreformjánál?
- Állandó-e a Föld forgási sebessége?
- Ki találta fel a pontos órát?

- Mi a különbség a GMT és az UTC között?
- Az UTC-ben van daylight saving?
- Mi a referenciadátum a unix időmérésében?

- Mekkor a Föld kerületi sebessége Budapestnél km/sec-ben?

- What are the leap seconds in UTC?

- Mi az az NTP? [MS Support for the leap second](https://learn.microsoft.com/en-us/troubleshoot/windows-server/active-directory/support-for-leap-second)

Linkek:

https://www.bordersofadventure.com/wp-content/uploads/2019/02/How-to-Visit-the-Greenwich-Meridian-Line-in-London.jpg

https://earth.nullschool.net/#current/chem/surface/level/overlay=so2smass/orthographic=39.23,21.60,433

https://upload.wikimedia.org/wikipedia/commons/4/48/Geoid_undulation_to_scale.jpg

https://thenauticalalmanac.com/TNARegular/2024_Nautical_Almanac.pdf


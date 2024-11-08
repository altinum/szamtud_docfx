import { applicationUrl } from "./main.js";

export async function manageHtmlChange(elements) {
  //hash létrehozása az elemek alapján
  const htmlContent = Array.from(elements)
    .map((element) => element.outerHTML)
    .join("");
  const currentHash = hashString(htmlContent);
  const site = await createSiteInfo();
  //hash érték frissítése az adatbázisban ha a benne lévőtől eltér
  const response = await fetch(
    `${applicationUrl}heatmap/currentHash/${site.siteId}`,
    {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(currentHash),
    }
  );
  const contentChanged = await response.json();

  //ha nincs előző hash vagy eltér, akkor frissítjük az adatbázist
  if (contentChanged) {
    console.log("Az oldal HTML szerkezete megváltozott.");

    await emptyDatabase(site.siteId);
    await createSectionInfo(elements);
    await createPositionInfo(elements);
  } else {
    try {
      //ha nem kell frissíteni az adatbázis akkor is le kell kérni a sectionöket és beállítani
      //az id-kat az elementeknek, hogy egyszerűbben lehessen hivatkozni rájuk
      const response = await fetch(
        `${applicationUrl}heatmap/sections/${site.siteId}`
      );
      let sections = await response.json();

      sections.forEach((section) => {
        elements.forEach((element) => {
          //olyan elemet keresünk, aminek az outerHTML-je megegyezik a section htmlElement-jével
          if (element.outerHTML === section.htmlElement) {
            element.id = section.sectionId.toString();
            //ha megtaláltuk, akkor eltávolítjuk a megtalált elemet a listából, hogy gyorsabban menjen a keresés
            elements = [...elements].filter((e) => e !== element);
          }
        });
      });
    } catch (error) {
      console.error("Error fetching sections:", error);
    }

    console.log("Az oldal HTML szerkezete nem változott.");
  }
}

//hash függvény a szöveg hash-ének létrehozására
function hashString(str) {
  let hash = 0;
  for (let i = 0; i < str.length; i++) {
    const char = str.charCodeAt(i);
    hash = (hash << 5) - hash + char;
    hash |= 0;
  }
  return hash.toString();
}

async function emptyDatabase(siteId) {
  try {
    await fetch(`${applicationUrl}heatmap/emptyDatabase/${siteId}`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
    });
  } catch (error) {
    console.log(error);
  }
}

async function createSiteInfo() {
  const response = await fetch(`${applicationUrl}heatmap/sites`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(window.location.href),
  });
  return await response.json();
}

async function createSectionInfo(elements) {
  const sectionPromises = [...elements].map(async (element) => {
    const response = await fetch(`${applicationUrl}heatmap/section`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        nodeName: element.nodeName,
        baseUrl: element.baseURI,
        outerHtml: element.outerHTML,
      }),
    });
    const section = await response.json();
    element.id = section.sectionId.toString();
  });

  //asyncronitás miatt meg kell várni az összes hívás lefutását
  await Promise.all(sectionPromises);
}

async function createPositionInfo(elements) {
  const positionPromises = [...elements].map(async (element) => {
    await fetch(`${applicationUrl}heatmap/position`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        sectionId: element.id,
        y: element.closest("table")
          ? element.offsetParent.offsetTop + element.offsetTop
          : element.offsetTop,
        height: element.offsetHeight,
      }),
    });
  });
  //asyncronitás miatt meg kell várni az összes hívás lefutását
  await Promise.all(positionPromises);
}

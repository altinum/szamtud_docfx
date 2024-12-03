import { fetchData, getSite } from "./main.js";

export async function manageHtmlChange(elements) {
  //hash létrehozása az elemek alapján
  const htmlContent = [...elements].map((el) => el.outerHTML).join("");
  const currentHash = hashString(htmlContent);

  const site = (await getSite()) ?? (await createSiteInfo());

  //az oldal hash értékének frissítése az adatbázisban ha a benne lévőtől eltér
  const contentChanged = await fetchData(
    `heatmap/currentHash/${site.siteId}`,
    "PUT",
    currentHash
  );

  //ha nincs előző hash vagy eltér, akkor frissítjük az adatbázist
  if (contentChanged) {
    localStorage.clear();
    await emptyDatabase(site.siteId);
    await createSectionInfo(elements);
    await createPositionInfo(elements);
  } else {
    try {
      //ha nem kell frissíteni az adatbázis akkor le kell kérni a sectionöket és beállítani az id-kat
      const sections = await fetchData(`heatmap/sections/${site.siteId}`);

      sections.forEach((section) => {
        const el = [...elements].find(
          (el) => el.outerHTML === section.htmlElement
        );
        if (el) {
          el.id = section.sectionId.toString();
          //ha megtaláltuk, akkor eltávolítjuk a megtalált elemet a listából, hogy gyorsabban menjen a keresés
          elements = [...elements].filter((e) => e !== el);
        }
      });
    } catch (error) {
      console.error("Error fetching sections:", error);
    }
  }
}

//a szöveg hash-ének létrehozására
function hashString(str) {
  return str
    .split("")
    .reduce((hash, char) => {
      hash = (hash << 5) - hash + char.charCodeAt(0);
      return hash | 0;
    }, 0)
    .toString();
}

async function emptyDatabase(siteId) {
  try {
    await fetchData(`heatmap/emptyDatabase/${siteId}`, "POST");
  } catch (error) {
    console.log(error);
  }
}

async function createSiteInfo() {
  return await fetchData(`heatmap/sites`, "POST", window.location.href);
}

async function createSectionInfo(elements) {
  const sectionPromises = [...elements].map(async (element) => {
    const section = await fetchData(`heatmap/section`, "POST", {
      nodeName: element.nodeName,
      baseUrl: element.baseURI,
      outerHtml: element.outerHTML,
    });
    element.id = section.sectionId.toString();
  });

  //asyncronitás miatt meg kell várni az összes hívás lefutását
  await Promise.all(sectionPromises);
}

async function createPositionInfo(elements) {
  const positionPromises = [...elements].map(async (element) => {
    await fetchData(`heatmap/position`, "POST", {
      sectionId: element.id,
      y: element.closest("table")
        ? element.offsetParent.offsetTop + element.offsetTop
        : element.offsetTop,
      height: element.offsetHeight,
    });
  });
  //asyncronitás miatt meg kell várni az összes hívás lefutását
  await Promise.all(positionPromises);
}

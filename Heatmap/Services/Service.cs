using Heatmap.Data;
using Heatmap.services;
using Microsoft.EntityFrameworkCore;

namespace Heatmap.Services;

public class Service
{
    private readonly HeatmapDbContext _context;

    public Service(HeatmapDbContext context)
    {
        _context = context;
    }

    public async Task EmptyDatabaseAsync(int siteId, CancellationToken cancellationToken)
    {
        IList<Section> sections =
            await _context.Sections.Where(s => s.SiteId == siteId).ToArrayAsync(cancellationToken);
        foreach (var section in sections)
        {
            HtmlElement? element =
                await _context.HtmlElements.SingleOrDefaultAsync(e => e.ElementId == section.HtmlElementId,
                    cancellationToken);
            if (element == null) _context.Remove(section);
            else _context.Remove(section);
        }

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> UpdateContentHashAsync(string hash, int siteId, CancellationToken cancellationToken)
    {
        Site site = await _context.Sites.SingleOrDefaultAsync(s => s.SiteId == siteId, cancellationToken) ??
                    throw new InvalidOperationException();

        SiteVersion siteVersion =
            (await _context.SiteVersions.SingleOrDefaultAsync(sv => sv.SiteId == site.SiteId, cancellationToken))!;
        if (siteVersion.ContentHash == hash) return false;

        siteVersion.ContentHash = hash;
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<Section> CreateSectionAsync(CreateSectionDto createSectionDto,
        CancellationToken cancellationToken)
    {
        HtmlElement? element =
            await _context.HtmlElements.SingleOrDefaultAsync(e => e.Element == createSectionDto.OuterHtml,
                cancellationToken);
        if (element != null)
            return await _context.Sections.SingleOrDefaultAsync(s => s.HtmlElementId == element.ElementId,
                cancellationToken);

        HtmlElementType? elementType =
            await _context.HtmlElementTypes.SingleOrDefaultAsync(t => t.TypeName == createSectionDto.NodeName,
                cancellationToken);
        Site? site =
            await _context.Sites.SingleOrDefaultAsync(s => s.SiteUrl == createSectionDto.BaseUrl, cancellationToken);

        if (site == null || elementType == null) throw new Exception();

        var newElement = await CreateHtmlElementAsync(createSectionDto.OuterHtml, cancellationToken);

        var section = new Section
        {
            HtmlElementId = newElement.ElementId,
            ElementTypeId = elementType.TypeId,
            SiteId = site.SiteId
        };

        await _context.Sections.AddAsync(section, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        await CreateVisibilityInfoAsync(section.SectionId, cancellationToken);
        return section;
    }

    private async Task<HtmlElement> CreateHtmlElementAsync(string outerHtml, CancellationToken cancellationToken)
    {
        var htmlElement = new HtmlElement
        {
            Element = outerHtml,
        };
        await _context.HtmlElements.AddAsync(htmlElement, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return htmlElement;
    }

    public async Task<Site> CreateSiteAsync(string siteUrl, CancellationToken cancellationToken)
    {
        Site? existingSite = await _context.Sites.SingleOrDefaultAsync(s => s.SiteUrl == siteUrl, cancellationToken);
        if (existingSite != null) return existingSite;

        var uri = new Uri(siteUrl);
        string subjectName = uri.Segments[1].TrimEnd('/');
        Subject? subject =
            await _context.Subjects.SingleOrDefaultAsync(s => s.SubjectName == subjectName, cancellationToken);
        if (subject == null) throw new Exception("Nincs a megadott url-hez tantárgy az adatbázisban!");

        var site = new Site
        {
            SiteUrl = siteUrl,
            SubjectId = subject.SubjectId
        };
        await _context.AddAsync(site, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        await CreateSiteVersionAsync(site.SiteId, cancellationToken);
        return site;
    }

    private async Task CreateSiteVersionAsync(int siteId, CancellationToken cancellationToken)
    {
        var siteVersion = new SiteVersion
        {
            SiteId = siteId,
            ContentHash = "kezdeti_hash_érték",
            LastUpdated = DateTime.Now,
        };
        await _context.AddAsync(siteVersion, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<Position?>> GetPositionsBySiteIdAsync(int siteId, CancellationToken cancellationToken)
    {
        Site site = await _context.Sites.SingleOrDefaultAsync(s => s.SiteId == siteId, cancellationToken) ??
                    throw new InvalidOperationException();
        IList<Section> sections =
            await _context.Sections.Where(s => s.SiteId == site.SiteId).ToArrayAsync(cancellationToken);

        var positions = new List<Position?>();
        foreach (var section in sections)
        {
            Position? position =
                await _context.Positions.FirstOrDefaultAsync(p => p.SectionId == section.SectionId, cancellationToken);
            positions.Add(position);
        }

        return positions;
    }

    public async Task<IList<VisibilityInfo?>> GetVisibilityInfosBySiteIdAsync(int siteId,
        CancellationToken cancellationToken)
    {
        Site site = await _context.Sites.SingleOrDefaultAsync(s => s.SiteId == siteId, cancellationToken) ??
                    throw new InvalidOperationException();
        IList<Section> sections =
            await _context.Sections.Where(s => s.SiteId == site.SiteId).ToArrayAsync(cancellationToken);

        var visibilityInfos = new List<VisibilityInfo?>();
        foreach (var section in sections)
        {
            VisibilityInfo? visibilityInfo =
                await _context.VisibilityInfos.FirstOrDefaultAsync(v => v.SectionId == section.SectionId,
                    cancellationToken);
            visibilityInfos.Add(visibilityInfo);
        }

        return visibilityInfos;
    }

    public async Task CreatePositionInfoAsync(Position position, CancellationToken cancellationToken)
    {
        await _context.AddAsync(position, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    private async Task CreateVisibilityInfoAsync(int sectionId, CancellationToken cancellationToken)
    {
        var visibilityInfo = new VisibilityInfo()
        {
            SectionId = sectionId,
            TotalVisibleTime = 0,
            LastVisibleTime = DateTime.Now
        };
        await _context.AddAsync(visibilityInfo, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateVisibilityInfoAsync(int sectionId, double visibleTime,
        CancellationToken cancellationToken)
    {
        VisibilityInfo? visibilityInfo = await _context.VisibilityInfos
            .SingleOrDefaultAsync(v => v.SectionId == sectionId, cancellationToken);

        if (visibilityInfo == null) return;

        visibilityInfo.TotalVisibleTime += visibleTime;
        visibilityInfo.LastVisibleTime = DateTime.Now;
        await _context.SaveChangesAsync(cancellationToken);
    }
}
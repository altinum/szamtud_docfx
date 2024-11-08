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

    public async Task EmptyDatabaseAsync(CancellationToken cancellationToken)
    {
        IList<Section> sections = await _context.Sections.ToArrayAsync(cancellationToken);
        foreach (var section in sections)
        {
            _context.Remove(section);
        }

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> UpdateContentHashAsync(string hash, int siteId, CancellationToken cancellationToken)
    {
        Site site = await _context.Sites.SingleOrDefaultAsync(s => s.SiteId == siteId, cancellationToken);

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
        Section? existingSection =
            await _context.Sections.SingleOrDefaultAsync(s => s.HtmlElement == createSectionDto.OuterHtml,
                cancellationToken);
        if (existingSection != null) return existingSection;

        HtmlElementType? elementType =
            await _context.HtmlElementTypes.SingleOrDefaultAsync(t => t.TypeName == createSectionDto.NodeName,
                cancellationToken);
        Site? site =
            await _context.Sites.SingleOrDefaultAsync(s => s.SiteUrl == createSectionDto.BaseUrl, cancellationToken);

        if (site == null || elementType == null) throw new Exception();

        var section = new Section
        {
            HtmlElement = createSectionDto.OuterHtml,
            ElementType = elementType.TypeId,
            SiteId = site.SiteId
        };

        await _context.AddAsync(section, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        await CreateVisibilityInfoAsync(section.SectionId, cancellationToken);
        return section;
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
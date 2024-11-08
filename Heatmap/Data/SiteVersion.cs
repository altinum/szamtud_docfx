namespace Heatmap.Data;

public class SiteVersion
{
    public int Id { get; set; }
    
    public int SiteId { get; set; }
    public string ContentHash { get; set; }
    
    public DateTime LastUpdated { get; set; }
}
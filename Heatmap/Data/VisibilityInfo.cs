namespace Heatmap.Data;

public class VisibilityInfo {
    public int Id { get; set; }

    public int SectionId { get; set; }

    public double TotalVisibleTime { get; set; }
    
    public DateTime LastVisibleTime { get; set; }
}
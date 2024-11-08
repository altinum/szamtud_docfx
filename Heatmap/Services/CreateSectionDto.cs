namespace Heatmap.services;

public class CreateSectionDto {
    public int Id { get; set; }

    public string NodeName { get; set; }

    public string BaseUrl { get; set; }

    public string OuterHtml { get; set; }
}
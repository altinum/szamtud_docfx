using Microsoft.EntityFrameworkCore;

public class HeatmapDbContext : DbContext
{
    public HeatmapDbContext(DbContextOptions<HeatmapDbContext> options) : base(options) { }

    public DbSet<Subject> Subjects { get; set; }

    public DbSet<HtmlElementType> HtmlElementTypes { get; set; }

    public DbSet<Position> Positions { get; set; }

    public DbSet<Section> Sections { get; set; }

    public DbSet<Site> Sites { get; set; }

    public DbSet<VisibilityInfo> VisibilityInfos { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entity.GetProperties())
            {
                var newName = ConvertToSnakeCase(property.Name);
                property.SetColumnName(newName);
            }
        }

        base.OnModelCreating(modelBuilder);
    }

   private string ConvertToSnakeCase(string name)
   {
    if (string.IsNullOrWhiteSpace(name)) return name;
    return string.Concat(name.Select((x, i) => 
        i > 0 && char.IsUpper(x) ? "_" + x.ToString().ToLower() : x.ToString()
        ));
    }
}



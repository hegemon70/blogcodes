using System.Data.Entity;
namespace CompositeEF_Sitemap
{
    public class ApplicationContext : DbContext
    {

        public IDbSet<AppSiteMap> AppSiteMaps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppSiteMap>()
                .HasMany(x => x.Childs)
                .WithOptional(x => x.Parent);
            base.OnModelCreating(modelBuilder);
        }
    }
}


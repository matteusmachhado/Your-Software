using Microsoft.EntityFrameworkCore;

namespace YS.CMS.Infra.Data
{
    public class CMSContext : DbContext
    {
        public CMSContext(DbContextOptions options) : base(options)
        {
            this.Database.MigrateAsync();
        }
    }
}

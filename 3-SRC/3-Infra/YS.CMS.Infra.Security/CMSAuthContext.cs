using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YS.CMS.Domain.Base.Entities;

namespace YS.CMS.Infra.Security
{
    public class CMSAuthContext : IdentityDbContext<User>
    {
        public CMSAuthContext(DbContextOptions<CMSAuthContext> dbContext) : base(dbContext)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}

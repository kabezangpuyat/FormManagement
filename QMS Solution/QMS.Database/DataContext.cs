using Microsoft.EntityFrameworkCore;
using QMS.Core.Database;
using QMS.Domain.Entities;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace QMS.Database
{
    public class DataContext : DbContext, IDataContext
    {

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("OrderNumbers", schema: "shared")
                .StartsAt(1).IncrementsBy(1);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
#if DEBUG

            Seed.Initialiaze(modelBuilder);

#endif
        }

        #region IDataContext
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<AppNavigation> AppNavigation { get; set; }
        public DbSet<RoleAppNavigation> RoleAppNavigation { get; set; }
        public DbSet<Campaign> Campaign { get; set; }
        public DbSet<Lob> Lob { get; set; }
        public DbSet<FormType> FormType { get; set; }
        public DbSet<FormCategory> FormCategory { get; set; }
        public DbSet<Form> Form { get; set; }
        public DbSet<FormQuestion> FormQuestion { get; set; }
        public DbSet<FormChoice> FormChoice { get; set; }
        public DbSet<HtmlControl> HtmlControl { get; set; }
        public DbSet<FormQuestionChoice> FormQuestionChoice { get; set; }
        public DbSet<UserCampaign> UserCampaign { get; set; }
        public DbSet<AuditDetail> AuditDetail { get; set; }
        public DbSet<Audit> Audit { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
        } 
        #endregion
    }
}

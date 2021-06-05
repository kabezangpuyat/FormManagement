using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using QMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QMS.Core.Database
{
    public interface IDataContext : IDisposable
    {
        DbSet<User> User { get; set; }
        DbSet<Role> Role { get; set; }
        DbSet<UserRole> UserRole { get; set; }
        DbSet<RefreshToken> RefreshToken { get; set; }
        DbSet<AppNavigation> AppNavigation { get; set; }
        DbSet<RoleAppNavigation> RoleAppNavigation { get; set; }
        DbSet<Campaign> Campaign { get; set; }
        DbSet<Lob> Lob { get; set; }
        DbSet<FormType> FormType { get; set; }
        DbSet<FormCategory> FormCategory { get; set; }
        DbSet<Form> Form { get; set; }
        DbSet<FormQuestion> FormQuestion { get; set; }
        DbSet<FormChoice> FormChoice { get; set; }
        DbSet<HtmlControl> HtmlControl { get; set; }
        DbSet<FormQuestionChoice> FormQuestionChoice { get; set; }
        DbSet<UserCampaign> UserCampaign { get; set; }
        DbSet<AuditDetail> AuditDetail { get; set; }
        DbSet<Audit> Audit { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        int SaveChanges();
        DatabaseFacade Database { get; }
        EntityEntry Entry([NotNullAttribute] object entity);
    }
}

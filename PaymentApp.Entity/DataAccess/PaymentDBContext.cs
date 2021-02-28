using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentApp.Common.StaticConstants;
using PaymentApp.Entity.BaseEntity;
using PaymentApp.Entity.Model.Payment;

namespace PaymentApp.Entity.DataAccess
{
    public class PaymentDBContext : DbContext
    {
        public PaymentDBContext()
        {

        }
        public PaymentDBContext(DbContextOptions<PaymentDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Constants.ConnectionString);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            SaveAuditInfo();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            SaveAuditInfo();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public void SaveAuditInfo()
        {
            foreach (var auditableEntity in ChangeTracker.Entries<AuditInfoBaseEntity>())
            {
                if (auditableEntity.State == EntityState.Added ||
                    auditableEntity.State == EntityState.Modified)
                {
                    auditableEntity.Entity.ModifiedDate = DateTime.UtcNow;

                    if (auditableEntity.State == EntityState.Added)
                    {
                        auditableEntity.Entity.CreatedDate = DateTime.UtcNow;
                    }
                    else
                    {
                        auditableEntity.Property(p => p.CreatedDate).IsModified = false;
                        auditableEntity.Property(p => p.CreatedBy).IsModified = false;
                    }
                }
                if (auditableEntity.Entity.IsDeleted)
                {
                    auditableEntity.Entity.DeletedDate = DateTime.UtcNow;
                }
            }
        }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentStatus> PaymentStatus { get; set; }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JwtTest.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Work> Works { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //    modelBuilder.Entity<CustomerSubscription>()
            //          .HasKey(m => new { m.SubscriptionId, m.CustomerId });


            modelBuilder.Entity<Register>()
                   .HasOne(p => p.Customer)
                   .WithMany(b => b.Registers)
                   .HasForeignKey(p => p.CustomerId)
                   .HasPrincipalKey(b => b.QrCode);


            //}

            //    protected override void OnModelCreating(ModelBuilder modelBuilder)
            //    {
            //        base.OnModelCreating(modelBuilder);


            //        modelBuilder.Entity<CustomerSubscription>()
            //            .HasKey(t => new { t.SubscriptionId, t.CustomerId });

            //        modelBuilder.Entity<CustomerSubscription>()
            //            .HasOne(pt => pt.Subscription)
            //            .WithMany(p => p.customerSubscriptions)
            //            .HasForeignKey(pt => pt.SubscriptionId);

            //        modelBuilder.Entity<CustomerSubscription>()
            //            .HasOne(pt => pt.Customer)
            //            .WithMany(t => t.customerSubscriptions)
            //            .HasForeignKey(pt => pt.CustomerId);
            //    }
            //}


            //        //builder.Entity<Customer>()
            //        //.Property(t => t.CustomerId).ValueGeneratedNever();

            //        builder.Entity<Customer>()
            // .HasKey(e => new
            // {
            //     e.CustomerId,
            //     e.QrCode
            // });


            //protected override void OnModelCreating(ModelBuilder builder)
            //{
            //    base.OnModelCreating(builder);
            //    builder.Entity<Register>()
            //              .HasOne(p => p.Customer)
            //              .WithMany(b => b.Registers)
            //              .HasForeignKey(p => p.CustomerId)
            //              .HasPrincipalKey(b => b.CustomerQrcode);
            //    //.HasAlternateKey(c => new { c.CustomerId, c.CustomerQrcode });

            //}
        }


    }
}

    
using BelissimoCloneWPF.Domain.Entities.Attachment;
using BelissimoCloneWPF.Domain.Entities.Branches;
using BelissimoCloneWPF.Domain.Entities.Foods;
using BelissimoCloneWPF.Domain.Entities.Orders;
using BelissimoCloneWPF.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace BelissimoCloneWPF.Data.Contexts
{
    public class BelissimoDbContext : DbContext
    {
        

        public virtual DbSet<Attachments> Attachments { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<FoodOrder> FoodOrders { get; set; }
        public virtual DbSet<Basket> Baskets { get; set; }
        public virtual DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Database=DbBelissimoCloneWPF; Username=postgres; Password=7464784");
        }
    }

}

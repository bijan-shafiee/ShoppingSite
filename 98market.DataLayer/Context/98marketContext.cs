using _98market.DataLayer.Entities;
using _98market.DataLayer.Entities.Address;
using _98market.DataLayer.Entities.DisCount;
using _98market.DataLayer.Entities.Entitieproduct;
using _98market.DataLayer.Entities.Entitieproduct.FaQ;
using _98market.DataLayer.Entities.Role;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _98market.DataLayer.Context
{
   public class _98marketContext:DbContext
   {
        public _98marketContext(DbContextOptions<_98marketContext> option) :base(option)
        {

        }
        public DbSet <MainSlider> mainSliders { get; set; }
        public DbSet<user> users { get; set; }
        public DbSet<IndexImage> IndexImages { get; set; }

        #region FaQ
        public DbSet<Answer> answers { get; set; }
        public DbSet<comment> comments { get; set; }
        public DbSet<question> questions { get; set; }
        public DbSet<Rate> Rates { get; set; }
        #endregion

        #region Product

        public DbSet<brand> brands { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<product> products { get; set; }
        public DbSet<productColor> ProductColors { get; set; }
        public DbSet<ProductGallery> ProductGalleries { get; set; }
        public DbSet<ProductGurantee> productGurantees { get; set; }
        public DbSet<PropertyName> propertyNames { get; set; }
        public DbSet<Propertyname_Category> propertyname_Categories { get; set; }
        public DbSet<PropertyValue> propertyValues { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<Faviorate> Faviorates { get; set; }
        public DbSet<ProductReating> ProductReatings { get; set; }
        public DbSet<ProductView> ProductViews { get; set; }
        #endregion

        #region Address
        public DbSet<Province> provinces { get; set; }
        public DbSet<city> cities { get; set; }
        public DbSet<useraddress> useraddresses { get; set; }
        #endregion

        #region Cart

        public DbSet<Cart> cart { get; set; }
        public DbSet<CartDetail> CartDetail { get; set; }
        public DbSet<TrackingPrice> TrackingPrice { get; set; }
        #endregion

        #region Discount
        public DbSet<discount> discounts { get; set; }
        public DbSet<UserDiscount> UserDiscounts { get; set; }
        #endregion

        #region RolePermission

        public DbSet<role> roles { get; set; }
        public DbSet<permission> permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<discount>().HasQueryFilter(d => !d.IsDelete);

            base.OnModelCreating(modelBuilder);
        }
    }
}

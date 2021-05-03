using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolaCare.Models;

namespace HolaCare.Models
{
    public class DBHolaContext:DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Blog>()
                 .HasOne<TopicBlog>(s => s.TopicBlog)
                 .WithMany(g => g.Blogs)
                 .HasForeignKey(s => s.IDTopic);


            modelBuilder.Entity<Product>()
                .HasOne<Brand>(s => s.Brand)
                .WithMany(g => g.Products)
                .HasForeignKey(s => s.IDBrand);

            modelBuilder.Entity<Blog>()
                .HasOne<User>(s => s.User)
                .WithMany(g => g.Blogs)
                .HasForeignKey(s => s.IDUser);

            modelBuilder.Entity<CommentBlog>()
                .HasOne<Blog>(s => s.Blog)
                .WithMany(g => g.CommentBlogs)
                .HasForeignKey(s => s.IDBlog);
            

            modelBuilder.Entity<Product>()
                .HasOne<SkinType>(s => s.Skintype)
                .WithMany(g => g.Products)
                .HasForeignKey(s => s.IDSkintype);

            modelBuilder.Entity<Product>()
                .HasOne<ProductType>(s => s.ProductType)
                .WithMany(g => g.Products)
                .HasForeignKey(s => s.IDProductType);

            modelBuilder.Entity<Point>()
                .HasOne<SkinType>(s => s.Skintype)
                .WithMany(g => g.Points)
                .HasForeignKey(s => s.IDSkinType);
          

         

            modelBuilder.Entity<CommentProduct>()
                .HasOne<Product>(s => s.Product)
                .WithMany(g => g.CommentProducts)
                .HasForeignKey(s => s.IDProduct);
            

            modelBuilder.Entity<IngreProduct>().HasKey(sc => new { sc.IDIngre, sc.ID3code });

            modelBuilder.Entity<IngreProduct>()
            .HasOne<IngredientDetail>(sc => sc.IngredientDetail)
            .WithMany(s => s.IngreProducts)
            .HasForeignKey(sc => sc.IDIngre);

            modelBuilder.Entity<IngreProduct>()
                .HasOne<Product>(sc => sc.Product)
                .WithMany(s => s.IngreProducts)
                .HasForeignKey(sc => sc.ID3code);
        }
        public DbSet<TopicBlog> TopicBlogs { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CommentBlog> CommentBlogs { get; set; }
        public DbSet<SkinType> SkinTypes { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<CommentProduct> CommentProducts { get; set; }
        public DBHolaContext(DbContextOptions<DBHolaContext> options) : base(options) { }
        public DbSet<IngredientDetail> IngredientDetails { get; set; }
        public DbSet<IngreProduct> IngreProducts { get; set; }

    }
}

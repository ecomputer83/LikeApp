using LikeApp.Repository.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LikeApp.Repository.Context
{
    public class LikeAppDbContext : DbContext
    {
        public LikeAppDbContext(DbContextOptions options) : base(options) { 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Article>().HasData(new Article { Id = 1, Title = "", Body = "", DatePublished = DateTime.Now });
        }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleLike> ArticleLikes { get; set; }
    }
}

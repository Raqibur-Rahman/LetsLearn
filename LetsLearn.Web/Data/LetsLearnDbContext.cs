

using LetsLearn.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LetsLearn.Web.Data
{
    public class LetsLearnDbContext : DbContext
    {
        public LetsLearnDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tag { get; set; }
       
    }
}

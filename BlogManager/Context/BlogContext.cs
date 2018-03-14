using BlogManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogManager.Context
{
    public class BlogContext: DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> opt): base(opt)
        {

        }

        public DbSet<User> Users{ get; set; }
        public DbSet<Blog> Blogs{ get; set; }
    }
}

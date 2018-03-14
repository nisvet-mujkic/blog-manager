using BlogManager.Context;
using BlogManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogManager.Helper
{
    public static class DummyDataGenerator
    {
        public static void GenerateData(BlogContext db)
        {
            new List<User>()
            {
                new User(){Name = "Nisvet Mujkic", Email = "nisvet@fit.ba", Age = 22},
                new User(){Name = "Eman Basic", Email = "eman@fit.ba", Age = 21},
                new User(){Name = "Ahmed Arnaut", Email = "ahmed@fit.ba", Age = 20},
                new User(){Name = "Mirnes Cerimovic", Email = "mirnes@fit.ba", Age = 24},
                new User(){Name = "Admir Odobasic", Email = "admir@fit.ba", Age = 26},
                new User(){Name = "Amra Hindic", Email = "amra@fit.ba", Age = 27},
                new User(){Name = "Faruk Mujkic", Email = "faruk@fit.ba", Age = 18},
                new User(){Name = "Seherzada Mujkic", Email = "seherzada@fit.ba", Age = 25},
                new User(){Name = "Adem Mujkic", Email = "adem@fit.ba", Age = 23},
                new User(){Name = "Ibrahim Suta", Email = "ibrahim@fit.ba", Age = 24},
                new User(){Name = "Mirza Medar", Email = "mirza@fit.ba", Age = 22},
                new User(){Name = "Ajdin Varenikic", Email = "ajdin@fit.ba", Age = 20},
                new User(){Name = "Emir Cajic", Email = "emir@fit.ba", Age = 23},
                new User(){Name = "Almir Vuk", Email = "almir@fit.ba", Age = 25},
                new User(){Name = "Jasmin Azemovic", Email = "jasmin@fit.ba", Age = 39}
            }.ForEach(x => db.Add(x));

            new List<Blog>()
            {
                new Blog(){Title = "Prvi blog", Content = "Neki content", Summary = "Summary prvog bloga", DateTime = new DateTime(2018, 2, 12), UserId = 9},
                new Blog(){Title = "Drugi blog", Content = "Neki content drugog bloga", Summary = "Summary drugog bloga", DateTime = new DateTime(2018, 4, 11), UserId = 9},
                new Blog(){Title = "Treci blog", Content = "Neki content drugog bloga", Summary = "Summary drugog bloga", DateTime = new DateTime(2018, 1, 22), UserId = 9},
                new Blog(){Title = "Cetrvrt blog", Content = "Neki content drugog bloga", Summary = "Summary drugog bloga", DateTime = new DateTime(2018, 5, 13), UserId = 9},
                new Blog(){Title = "Peti blog", Content = "Neki content drugog bloga", Summary = "Summary drugog bloga", DateTime = new DateTime(2018, 2, 7), UserId = 9},
                new Blog(){Title = "Sesti Drugi blog", Content = "Neki content drugog bloga", Summary = "Summary drugog bloga", DateTime = new DateTime(2018, 3, 22), UserId = 9},
                new Blog(){Title = "Sedmi blog", Content = "Neki content drugog bloga", Summary = "Summary drugog bloga", DateTime = new DateTime(2018, 4, 4), UserId = 9}
            }.ForEach(x => db.Blogs.Add(x));

            db.SaveChanges();
        }
    }
}

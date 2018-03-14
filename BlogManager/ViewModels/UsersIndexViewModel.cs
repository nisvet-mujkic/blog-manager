using BlogManager.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogManager.ViewModels
{
    public class UsersIndexViewModel
    {
        public string SearchTerm { get; set; }
        public Pagination PaginationHelper{ get; set; }
        public IEnumerable<Row> Rows { get; set; }

        public class Row
        {
            public int UserId { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string Email { get; set; }
            public int NumberOfBlogsCreated { get; set; }
        }
    }
}

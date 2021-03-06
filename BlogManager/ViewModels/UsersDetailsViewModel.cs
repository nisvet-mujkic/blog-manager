﻿using BlogManager.Helper;
using BlogManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogManager.ViewModels
{
    public class UsersDetailsViewModel
    {
        public User User{ get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public IEnumerable<Row> Rows { get; set; }
        public Pagination PaginationHelper { get; set; }
        public class Row
        {
            public int BlogId { get; set; }
            public string Title { get; set; }
            public string Summary { get; set; }
            public DateTime PublishingDateTime { get; set; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogManager.Context;
using BlogManager.Helper;
using BlogManager.Models;
using BlogManager.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BlogManager.Controllers
{
    public class UsersController : Controller
    {
        #region DI
        private readonly BlogContext db;
        private readonly PaginationSettings settings;
        public UsersController(BlogContext db, IOptions<PaginationSettings> settings)
        {
            this.db = db;
            this.settings = settings.Value;
        }
        #endregion

        #region Index
        public IActionResult Index(string searchTerm, int page = 1)
        {
            UsersIndexViewModel viewModel = new UsersIndexViewModel();

            int PageSize = settings.ItemsPerPage;

            viewModel.Rows = db.Users.Where(x => x.Name.Contains(searchTerm) || x.Email.Contains(searchTerm) || string.IsNullOrEmpty(searchTerm)).Select(x => new UsersIndexViewModel.Row()
            {
                UserId = x.Id,
                Email = x.Email,
                Name = x.Name,
                Age = x.Age,
                NumberOfBlogsCreated = (int?)db.Blogs.Where(b => b.UserId == x.Id).Count() ?? 0
            }).OrderBy(x => x.Name).Skip((page - 1) * PageSize).Take(PageSize).ToList();
            viewModel.PaginationHelper = new Pagination()
            {
                ItemsPerPage = PageSize,
                CurrentPage = page,
                TotalItems = db.Users.Where(x => x.Name.Contains(searchTerm) || x.Email.Contains(searchTerm) || string.IsNullOrEmpty(searchTerm)).Count()
            };

            return View(viewModel);
        }
        #endregion

        #region Details

        public IActionResult Details(int? userId, DateTime? dateFrom, DateTime? dateTo, int page = 1)
        {
            if (userId == null)
                return BadRequest();

            User user = db.Users.Find(userId);

            if (user == null)
                return NotFound();

            int PageSize = settings.ItemsPerPage;

            UsersDetailsViewModel viewModel = new UsersDetailsViewModel()
            {
                User = user,
                Rows = db.Blogs.Where(x => x.UserId == user.Id && (x.DateTime >= dateFrom || dateFrom == null) && (x.DateTime <= dateTo || dateTo == null)).Select(x => new UsersDetailsViewModel.Row()
                {
                    BlogId = x.Id,
                    PublishingDateTime = x.DateTime,
                    Summary = x.Summary,
                    Title = x.Title
                }).OrderBy(x => x.PublishingDateTime).Skip((page - 1) * PageSize).Take(PageSize).ToList(),
                PaginationHelper = new Pagination()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = db.Blogs.Where(x => x.UserId == user.Id && (x.DateTime >= dateFrom || dateFrom == null) && (x.DateTime <= dateTo || dateTo == null)).Count()
                }
            };

            return View(viewModel);
        }

        #endregion
    }
}
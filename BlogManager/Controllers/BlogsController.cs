using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogManager.Context;
using BlogManager.Extensions;
using BlogManager.Models;
using BlogManager.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogManager.Controllers
{
    public class BlogsController : Controller
    {
        // mislio sam da ce mi sesija biti potreba radi filtriranja sadrzaja, jer sam prvobitno radio sa AJAX-om
        #region DI
        private readonly BlogContext db;
        private readonly IHttpContextAccessor httpContextAccessor;

        public BlogsController(BlogContext db, IHttpContextAccessor httpContextAccessor)
        {
            this.db = db;
            this.httpContextAccessor = httpContextAccessor;
        }
        #endregion

        #region SessionProperty
        private BlogsIndexViewModel TempData
        {
            get { return httpContextAccessor.HttpContext.Session.GetJson<BlogsIndexViewModel>("blogs"); }
            set { httpContextAccessor.HttpContext.Session.SetJson("blogs", value); }
        }
        #endregion

        #region Index
        public IActionResult Index(int userId, DateTime? dateFrom, DateTime? dateTo)
        {
            if (TempData != null)
            {
                return null;
            }
            else
            {
                BlogsIndexViewModel viewModel = new BlogsIndexViewModel();

                viewModel.UserId = userId;
                viewModel.Rows = db.Blogs.Where(x => x.UserId == userId).Select(x => new BlogsIndexViewModel.Row()
                {
                    BlogId = x.Id,
                    PublishingDateTime = x.DateTime,
                    Summary = x.Summary,
                    Title = x.Title
                }).ToList();

                return PartialView(viewModel);
            }

        }
        #endregion

        #region Add
        [HttpPost]
        public IActionResult AddOrEdit(Blog blog)
        {
            if (DateTime.Now > blog.DateTime)
                ModelState.AddModelError("DateError", "Published Date cannot be in the past");

            if (!ModelState.IsValid)
            {
                List<string> errorList = ModelState.Values.SelectMany(x => x.Errors.Select(e => e.ErrorMessage)).ToList();
                return Json(new { success = false, errors = errorList });
            }

            if (blog.Id == 0)
                db.Blogs.Add(blog);
            else
                db.Blogs.Update(blog);

            db.SaveChanges();
            return Json(new { success = true, errors = "" });

        }
        #endregion

        #region Update
        public IActionResult Update(int id) => PartialView("_UpdateBlogPartial", db.Blogs.Find(id));
       
        #endregion
    }
}
using LetsLearn.Web.Data;
using LetsLearn.Web.Models.Domain;
using LetsLearn.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace LetsLearn.Web.Pages.Admin.Blogs
{
    public class AddModel : PageModel
    {
        private readonly LetsLearnDbContext letsLearnDbContext;

        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }

        public AddModel(LetsLearnDbContext letsLearnDbContext)
        {
            this.letsLearnDbContext = letsLearnDbContext;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            var blogPost = new BlogPost()
            {
                Heading = AddBlogPostRequest.Heading,
                PageTitle = AddBlogPostRequest.PageTitle,
                Content = AddBlogPostRequest.Content,
                ShortDescription = AddBlogPostRequest.ShortDescription,
                LongDescription = AddBlogPostRequest.LongDescription,
                FeaturedImageUrl = AddBlogPostRequest.FeaturedImageUrl,
                UrlHandle = AddBlogPostRequest.UrlHandle,
                PublishedDate = AddBlogPostRequest.PublishedDate,
                Author = AddBlogPostRequest.Author,
                IsVisiable = AddBlogPostRequest.IsVisiable

            };

            letsLearnDbContext.BlogPosts.Add(blogPost);
            letsLearnDbContext.SaveChanges();

            return RedirectToPage("/Admin/Blogs/List");
            
        }
      
    }
}

using LetsLearn.Web.Data;
using LetsLearn.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LetsLearn.Web.Pages.Admin.Blogs
{
   
    public class EditModel : PageModel
    {
        private readonly LetsLearnDbContext letsLearnDbContext;
        [BindProperty]
        public BlogPost BlogPost { get; set; }
        public EditModel(LetsLearnDbContext letsLearnDbContext)
        {
            this.letsLearnDbContext = letsLearnDbContext;
        }





        public void OnGet(Guid id)
        {
            BlogPost = letsLearnDbContext.BlogPosts.Find(id);
           
        }
        public IActionResult OnPostEdit()
        {
          var existingBlogPost = letsLearnDbContext.BlogPosts.Find(BlogPost.Id);
          if (existingBlogPost != null) 
            {
                existingBlogPost.Heading = BlogPost.Heading;
                existingBlogPost.PageTitle = BlogPost.PageTitle;    
                existingBlogPost.Content    = BlogPost.Content;
                existingBlogPost.ShortDescription = BlogPost.ShortDescription;
                existingBlogPost.FeaturedImageUrl = BlogPost.FeaturedImageUrl;  
                existingBlogPost.UrlHandle  = BlogPost.UrlHandle;
                existingBlogPost.PublishedDate  = BlogPost.PublishedDate;
                existingBlogPost.Author = BlogPost.Author;
                existingBlogPost.IsVisiable= BlogPost.IsVisiable;

            }

            letsLearnDbContext.SaveChanges();
            return RedirectToPage("/Admin/Blogs/List");
        }


        public IActionResult OnPostDelete()
        {
            var existingBlog = letsLearnDbContext.BlogPosts.Find(BlogPost.Id);
            if(existingBlog != null)
            {
                letsLearnDbContext.BlogPosts.Remove(existingBlog);
                letsLearnDbContext.SaveChanges();
                return RedirectToPage("/Admin/Blogs/List");
            }

            return Page();
        }



    }
}

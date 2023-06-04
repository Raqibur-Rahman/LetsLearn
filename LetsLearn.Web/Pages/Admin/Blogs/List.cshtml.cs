using LetsLearn.Web.Data;
using LetsLearn.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LetsLearn.Web.Pages.Admin.Blogs
{
    public class ListModel : PageModel
    {
        private readonly LetsLearnDbContext letsLearnDbContext;



        public List<BlogPost> BlogPosts{ get; set; }


        public ListModel( LetsLearnDbContext letsLearnDbContext)
        {
            this.letsLearnDbContext = letsLearnDbContext;
        }

        public void OnGet()
        {
          BlogPosts = letsLearnDbContext.BlogPosts.ToList();
        }

    }
}

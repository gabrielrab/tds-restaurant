using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TodoApi.Data.Repository;
using TodoApi.Data.Repository.Models;

namespace TodoApi.Pages.Configurations.Categories
{
    public class Edit : PageModel
    {
        private readonly Context context;

        public Edit(Context context)
        {
            this.context = context;
        }

        [BindProperty]
        public CategoryModel? category { get; set; }

        public void OnGet(int id)
        {
            var categoryModel = context.CategoryModel?.Find(id);

            if (categoryModel != null)
            {
                this.category = categoryModel;
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (category != null)
            {
                context.CategoryModel?.Update(category);
                context.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}

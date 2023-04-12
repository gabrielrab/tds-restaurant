using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TodoApi.Data.Repository;
using TodoApi.Data.Repository.Models;

namespace TodoApi.Pages.Configurations.Products
{
    public class Delete : PageModel
    {
        private readonly Context context;

        public Delete(Context context)
        {
            this.context = context;
        }

        public IActionResult OnGet(int id)
        {
            var productModel = context.ProductModel?.Find(id);

            if (productModel != null)
            {
                context.ProductModel?.Remove(productModel);
                context.SaveChanges();
            }
            return RedirectToPage("Index");

        }

    }
}

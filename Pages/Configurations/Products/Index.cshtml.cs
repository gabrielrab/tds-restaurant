using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TodoApi.Data.Repository;
using TodoApi.Data.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Pages.Configurations.Products
{
    public class Index : PageModel
    {

        private readonly Context context;

        public Index(Context context)
        {
            this.context = context;
        }
        public List<ProductModel> products = new();

        public void OnGet()
        {
            products = context.ProductModel?.Include(p => p.Category).ToList() ?? new List<ProductModel>();
        }
    }
}

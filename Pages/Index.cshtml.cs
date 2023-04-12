using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TodoApi.Data.Repository;
using TodoApi.Data.Repository.Models;

namespace Pages
{
    public class Index : PageModel
    {
        private readonly Context context;

        public Index(Context context)
        {
            this.context = context;
        }
        public List<TableModel> tables = new();

        public void OnGet()
        {
            tables = context.TableModel?.ToList() ?? new List<TableModel>();
        }
    }
}
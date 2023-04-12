using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TodoApi.Data.Repository;
using TodoApi.Data.Repository.Models;

namespace TodoApi.Pages.Configurations.Tables
{
    public class Edit : PageModel
    {
        private readonly Context context;

        public Edit(Context context)
        {
            this.context = context;
        }

        [BindProperty]
        public TableModel? table { get; set; }

        public void OnGet(int id)
        {
            var tableModel = context.TableModel?.Find(id);

            if (tableModel != null)
            {
                this.table = tableModel;
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (table != null)
            {
                context.TableModel?.Update(table);
                context.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}

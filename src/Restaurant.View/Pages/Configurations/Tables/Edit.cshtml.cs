using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Data.Data.Repository.Models;

namespace Restaurant.View.Pages.Configurations.Tables
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

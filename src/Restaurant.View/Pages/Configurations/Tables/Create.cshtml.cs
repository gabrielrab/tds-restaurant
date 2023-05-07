using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Data.Data.Repository.Models;

namespace Restaurant.View.Pages.Configurations.Tables
{
    public class Create : PageModel
    {
        private readonly Context context;

        public Create(Context context)
        {
            this.context = context;
        }

        [BindProperty]
        public TableModel? Table { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int id = 0;
            var lastTable = context.TableModel?.OrderByDescending(p => p.Id).FirstOrDefault();

            if (lastTable != null)
            {
                id = lastTable.Id + 1;
            }

            if (Table != null)
            {
                context.TableModel?.Add(new TableModel(id, Table.Code, false, null));
                context.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}

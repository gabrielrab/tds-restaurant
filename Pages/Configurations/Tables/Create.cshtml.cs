using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoApi.Data.Repository;
using TodoApi.Data.Repository.Models;

namespace TodoApi.Pages.Configurations.Tables
{
    public class Create : PageModel
    {
        private readonly Context context;

        public Create(Context context)
        {
            this.context = context;
        }

        [BindProperty]
        public TableModel? table { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int id = 0;
            var lastTable = context.TableModel?.OrderByDescending(p => p.Id)
            .FirstOrDefault();

            if (lastTable != null)
            {
                id = lastTable.Id + 1;
            }

            if (table != null)
            {
                context.TableModel?.Add(
                    new TableModel(id, table.Code, false, null)
                );
                context.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}

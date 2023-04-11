using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoApi.Data.Repository;
using TodoApi.Data.Repository.Models;

namespace TodoApi.Pages.Configurations.Waiters
{
    public class Edit : PageModel
    {
        private readonly Context context;

        public Edit(Context context)
        {
            this.context = context;
        }

        [BindProperty]
        public WaiterModel? waiter { get; set; }

        public void OnGet(int id)
        {
            var waiterModel = context.WaiterModel?.Find(id);

            if (waiterModel != null)
            {
                this.waiter = waiterModel;
            }
        }

        public IActionResult OnPost()
        {
            if (waiter != null)
            {
                context.WaiterModel?.Update(waiter);
                context.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}

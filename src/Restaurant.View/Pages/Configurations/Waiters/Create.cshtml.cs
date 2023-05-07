using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Data.Data.Repository.Models;

namespace Restaurant.View.Pages.Configurations.Waiters
{
    public class Create : PageModel
    {
        private readonly Context context;

        public Create(Context context)
        {
            this.context = context;
        }

        [BindProperty]
        public WaiterModel? waiter { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int id = 0;
            var lastWaiter = context.WaiterModel?.OrderByDescending(p => p.Id).FirstOrDefault();

            if (lastWaiter != null)
            {
                id = lastWaiter.Id + 1;
            }

            if (waiter != null)
            {
                context.WaiterModel?.Add(
                    new WaiterModel(
                        id,
                        waiter.Code,
                        waiter.FirstName,
                        waiter.LastName,
                        waiter.Phone
                    )
                );
                context.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}

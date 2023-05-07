using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Data.Data.Repository.Models;

namespace Restaurant.View.Pages.Configurations.Waiters
{
    public class Index : PageModel
    {
        private readonly Context context;

        public Index(Context context)
        {
            this.context = context;
        }

        public List<WaiterModel> waiters = new();

        public void OnGet()
        {
            waiters = context.WaiterModel?.ToList() ?? new List<WaiterModel>();
        }
    }
}

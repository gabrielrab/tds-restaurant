using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Data.Data.Repository.Models;

namespace Restaurant.View.Pages.Configurations.Tables
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

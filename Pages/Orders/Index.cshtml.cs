using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TodoApi.Data.Repository;
using TodoApi.Data.Repository.Models;

namespace TodoApi.Pages.Orders
{
public class Index : PageModel
    {
        private readonly Context context;

        public Index(Context context)
        {
            this.context = context;
        }
        public List<CategoryModel> categories = new();
        public List<ProductModel> products = new();
        public List<WaiterModel> waiters = new();
        public List<TableModel> tables = new();


        public void OnGet()
        {
            categories = context.CategoryModel?.ToList() ?? new List<CategoryModel>();
            products = context.ProductModel?.ToList() ?? new List<ProductModel>();
            waiters = context.WaiterModel?.ToList() ?? new List<WaiterModel>();
            tables = context.TableModel?.ToList() ?? new List<TableModel>();
        }
    }
}

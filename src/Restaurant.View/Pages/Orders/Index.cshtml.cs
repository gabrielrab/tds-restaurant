using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Data.Repository.Models;

namespace Restaurant.View.Pages.Orders
{
    public class Index : PageModel
    {
        private readonly Context context;

        public Index(Context context)
        {
            this.context = context;

            var tables = context.TableModel?.ToList() ?? new List<TableModel>();
            foreach (var table in tables ?? new())
            {
                this.tables.Add(
                    new SelectListItem($"Mesa {table.Code.ToString()}", table.Id.ToString())
                );
            }

            var waiters = context.WaiterModel?.ToList() ?? new List<WaiterModel>();
            foreach (var waiter in waiters ?? new())
            {
                this.waiters.Add(
                    new SelectListItem(
                        $"{waiter.FirstName} {waiter.LastName}",
                        waiter.Id.ToString()
                    )
                );
            }

            var products = context.ProductModel?.ToList() ?? new List<ProductModel>();
            foreach (var product in products ?? new())
            {
                this.products.Add(
                    new SelectListItem(
                        $"{product.Name} - R${product.Price},00",
                        product.Id.ToString()
                    )
                );
            }
        }

        public List<SelectListItem> categories = new();
        public List<SelectListItem> products = new();
        public List<SelectListItem> waiters = new();
        public List<SelectListItem> tables = new();

        [BindProperty]
        public int TableId { get; set; }

        [BindProperty]
        public int ProductId { get; set; }

        [BindProperty]
        public int WaiterId { get; set; }

        [BindProperty]
        public int Quantity { get; set; }

        public IActionResult OnPost()
        {
            var table = context.TableModel
                ?.Include(p => p.Services)
                .FirstOrDefault(p => p.Id == TableId);
            if (table!.Status)
            {
                var service_id = table.Services.LastOrDefault().Id;

                int id = 1;
                var lastService = context.ServiceLines
                    ?.OrderByDescending(p => p.Id)
                    .FirstOrDefault();
                if (lastService != null)
                {
                    id = lastService.Id + 1;
                }

                Console.WriteLine(
                    $"id: {id}, service_id: {service_id}, TableId: {TableId}, WaiterId: {WaiterId}, ProductId: {ProductId}, Quantity: {Quantity}"
                );

                context.ServiceLines?.Add(
                    new ServiceLineModel(id, service_id, TableId, WaiterId, ProductId, Quantity)
                );
                context.SaveChanges();
            }
            else
            {
                int service_id = 1;
                var lastService = context.ServiceModel
                    ?.OrderByDescending(p => p.Id)
                    .FirstOrDefault();
                if (lastService != null)
                {
                    service_id = lastService.Id + 1;
                }

                Console.WriteLine(
                    $"service_id: {service_id}, TableId: {TableId}, WaiterId: {WaiterId}, ProductId: {ProductId}, Quantity: {Quantity}"
                );
                context.ServiceModel?.Add(
                    new ServiceModel(service_id, TableId, DateTime.Now, null)
                );

                table.Status = true;
                context.TableModel?.Update(table);

                context.SaveChanges();

                int serviceLineId = 1;
                var lastServiceLine = context.ServiceLines
                    ?.OrderByDescending(p => p.Id)
                    .FirstOrDefault();
                if (lastServiceLine != null)
                {
                    serviceLineId = lastServiceLine.Id + 1;
                }

                Console.WriteLine(
                    $"id: {serviceLineId}, service_id: {service_id}, TableId: {TableId}, WaiterId: {WaiterId}, ProductId: {ProductId}, Quantity: {Quantity}"
                );
                context.ServiceLines?.Add(
                    new ServiceLineModel(
                        serviceLineId,
                        service_id,
                        TableId,
                        WaiterId,
                        ProductId,
                        Quantity
                    )
                );
                context.SaveChanges();
            }
            return Page();
        }
    }
}

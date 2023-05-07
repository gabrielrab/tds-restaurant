using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Data.Repository.Models;

namespace Restaurant.View.Pages.OrderDetails
{
    public class OrderDetail : PageModel
    {
        public double total { get; set; }

        public int serviceID { get; set; }

        public ServiceModel? service { get; set; }

        public List<ServiceLineModel>? serviceLines { get; set; }

        public TableModel? table { get; set; }

        private readonly Context context;

        public OrderDetail(Context context)
        {
            this.context = context;
        }

        public void OnGet(int? id)
        {
            var tableModel = context.TableModel
                ?.Include(p => p.Services)
                .FirstOrDefault(p => p.Id == id);

            if (tableModel != null)
            {
                this.table = tableModel;
                if (table.Status)
                {
                    total = 0;
                    serviceID = table.Services.LastOrDefault().Id;
                    service = context.ServiceModel
                        ?.Include(p => p.ServiceLines)
                        .FirstOrDefault(p => p.Id == serviceID);
                    serviceLines = service.ServiceLines;

                    foreach (var item in serviceLines)
                    {
                        var Service_Lines = context.ServiceLines
                            .Include(s => s.Product)
                            .FirstOrDefault(s => s.ServiceId == serviceID);
                        total += (Service_Lines.Product.Price * item.Quantity);
                    }
                }
            }
            else { }
        }
    }
}

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Data.Repository.Models;

namespace Restaurant.View.Pages.CloseService
{
    public class CloseService : PageModel
    {
        private readonly Context context;

        public CloseService(Context context)
        {
            this.context = context;
        }

        public int ServiceID { get; set; }

        public TableModel? Table { get; set; }

        public ServiceModel? Service { get; set; }

        public void OnGet(int id)
        {
            var tableModel = context.TableModel
                ?.Include(p => p.Services)
                .FirstOrDefault(p => p.Id == id);

            if (tableModel != null)
            {
                Table = tableModel;
                ServiceID = Table.Services.LastOrDefault().Id;
                Service = context.ServiceModel
                    ?.Include(p => p.ServiceLines)
                    .FirstOrDefault(p => p.Id == ServiceID);
            }

            Table.Status = false;
            Service.EndAt = DateTime.Now;

            context.TableModel.Update(Table);
            context.ServiceModel.Update(Service);
            context.SaveChanges();
        }
    }
}

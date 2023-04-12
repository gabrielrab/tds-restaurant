using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TodoApi.Data.Repository;
using TodoApi.Data.Repository.Models;


namespace TodoApi.Pages.CloseService
{
    public class CloseService : PageModel
    {

        private readonly Context context;

        public CloseService(Context context){
            this.context = context;
        }

        public TableModel? table;

        public ServiceModel? service;
        public void OnGet(int id)
        {

            var tableModel = context.TableModel?.Include(p => p.Services).FirstOrDefault(p => p.Id == id);


            if (tableModel != null)
            {
                this.table = tableModel;
                service = table.Services.Last();
            }

            table.Status = false;
            service.EndAt = DateTime.Now;

            context.TableModel.Update(table);
            context.ServiceModel.Update(service);
            context.SaveChanges();
        }
    }
}
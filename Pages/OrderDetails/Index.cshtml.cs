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

namespace TodoApi.Pages.OrderDetails
{
    public class OrderDetail : PageModel
    {

        public double total {get; set;}
        
        public int serviceID {get; set;}

        public ServiceModel? service {get; set;}

        public List<ServiceLineModel>? serviceLines {get; set;}

        public TableModel? table {get; set;}

        private readonly Context context;

        public OrderDetail(Context context){
            this.context = context;
        }


        public void OnGet(int? id)
        {
            Console.WriteLine(id);
            var tableModel = context.TableModel?.Include(p => p.Services).FirstOrDefault(p => p.Id == id);
          
            if (tableModel != null)
            {
            this.table = tableModel;
            if(table.Status){
                total = 0;
                serviceID = table.Services.LastOrDefault().Id;
                Console.WriteLine(serviceID);
                service = context.ServiceModel?.Include(p => p.ServiceLines).FirstOrDefault(p => p.Id == serviceID);
                serviceLines = service.ServiceLines;
                Console.WriteLine(service);
                

                    foreach(var item in serviceLines){
                        var Service_Lines = context.ServiceLines.Include(s => s.Product).FirstOrDefault(s => s.ServiceId == serviceID);
                        total = total +(Service_Lines.Product.Price * item.Quantity);
            }
                }
            }
            else{
                Console.WriteLine(table);
                Console.WriteLine(service);
            }
        }
    }
}

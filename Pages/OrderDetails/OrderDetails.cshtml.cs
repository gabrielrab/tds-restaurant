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

        public ServiceModel? service;

        public List<ProductModel>? products;

        public TableModel? table;

        private readonly Context context;

        public OrderDetail(Context context){
            this.context = context;
        }


        public void OnGet(int id)
        {
            
            var tableModel = context.TableModel?.Include(p => p.Services).FirstOrDefault(p => p.Id == id);

            if (tableModel != null)
            {
                this.table = tableModel;
            }


            service = tableModel?.Services.Last();
        
            products = service?.Products;
            
        }
    }
}

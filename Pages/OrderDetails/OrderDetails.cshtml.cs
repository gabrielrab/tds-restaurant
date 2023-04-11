using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TodoApi.Data.Repository.Models;

namespace TodoApi.Pages.OrderDetails
{
    public class OrderDetail : PageModel
    {

        public ServiceModel? service;

        public List<ProductModel>? products;


        public void OnGet(TableModel table)
        {
            service = table.Service;
        
            products = service?.Products;
            
        }
    }
}

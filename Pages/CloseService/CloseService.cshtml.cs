using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TodoApi.Data.Repository.Models;

namespace TodoApi.Pages.CloseService
{
    public class CloseService : PageModel
    {
        public void OnGet(ServiceModel service , TableModel table)
        {
            service.EndAt.ToLocalTime();
            table.Service = null;
        }
    }
}
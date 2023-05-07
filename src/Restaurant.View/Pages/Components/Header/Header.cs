using Microsoft.AspNetCore.Mvc;

namespace Restaurant.View.Pages.Components
{
    public class Header : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

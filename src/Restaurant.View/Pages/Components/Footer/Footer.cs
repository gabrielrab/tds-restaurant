using Microsoft.AspNetCore.Mvc;

namespace Restaurant.View.Pages.Components
{
    public class Footer : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Restaurant.View.Pages.Components
{
    public class ConfigurationMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
public class ConfigurationMenu : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}

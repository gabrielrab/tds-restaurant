using Microsoft.AspNetCore.Mvc;
public class Button : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}

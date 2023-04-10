using Microsoft.AspNetCore.Mvc;
public class Header : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}

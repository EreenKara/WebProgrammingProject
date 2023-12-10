using Microsoft.AspNetCore.Mvc;

namespace WebProgrammingProject.ViewComponents
{
    public class UcuslarViewComponent:ViewComponent
    {
        // Aşağıdaki yerde istersen view için veritabanından veri çekip gösterme işlemlerini yapabilrisin
        // Controller üzeirnde yapmamızın sebebi controller'ın asıl görevinin request'i karşılamak olamsı.
        public IViewComponentResult Invoke()
        {

            return View();
        }


    }
}

using AvSBookStore.YandexKassa.Areas.YandexKassa.Models;
using Microsoft.AspNetCore.Mvc;

namespace AvSBookStore.YandexKassa.Areas.YandexKassa.Controllers
{
    [Area("YandexKassa")]
    public class HomeController : Controller
    {
        public IActionResult Index(int orderId, string returnUri)
        {
            var model = new ExampleModel
            {
                OrderId = orderId,
                ReturnUri = returnUri
            };

            return View(model);
        }

        public IActionResult CallBack(int orderId, string returnUri)
        {
            var model = new ExampleModel
            {
                OrderId = orderId,
                ReturnUri = returnUri,
            };

            return View(model);
        }
    }
}

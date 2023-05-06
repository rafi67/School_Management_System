using Microsoft.AspNetCore.Mvc;

namespace StudentManagentSystem.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using APS.Security;
using APS.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace APS.Web.Controllers
{
    public class LoginController(ISecurityService service) : Controller
    {
        private readonly ISecurityService _service = service;

        public IActionResult Index()
        {
            return View("/Views/Accounts/Login.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            bool result = false;
            if (ModelState.IsValid)
                result = await _service.AuthUserByEmailAsync(new Data.Models.User { Email = model.Email, Password = model.Password });

            if (result)
                return RedirectToAction("Index", "Home");
            
            throw new Exception("Error");
        }
    }
}

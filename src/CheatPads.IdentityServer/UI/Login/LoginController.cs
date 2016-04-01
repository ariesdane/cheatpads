namespace CheatPads.IdentityServer.UI.Login
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using IdentityModel;
    using IdentityServer4.Core;
    using IdentityServer4.Core.Services;

    using Microsoft.AspNet.Mvc;

    using CheatPads.IdentityServer.Identity;

    public class LoginController : Controller
    {
        private readonly IdentityUserManager _loginService;
        private readonly SignInInteraction _signInInteraction;

        public LoginController(
            IdentityUserManager loginService, 
            SignInInteraction signInInteraction)
        {
            _loginService = loginService;
            _signInInteraction = signInInteraction;
        }

        [HttpGet(Constants.RoutePaths.Login, Name = "Login")]
        public async Task<IActionResult> Index(string id)
        {
            var vm = new LoginViewModel();

            if (id != null)
            {
                var request = await _signInInteraction.GetRequestAsync(id);
                if (request != null)
                {
                    vm.Username = request.LoginHint;
                    vm.SignInId = id;
                }
            }

            return View(vm);
        }

        [HttpPost(Constants.RoutePaths.Login)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginInputModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _loginService.FindByNameAsync(model.Username);

                if (user != null && await _loginService.CheckPasswordAsync(user, model.Password))
                {
                   
                    var claims = new Claim[] {
                        new Claim(JwtClaimTypes.Subject, user.Id),
                        new Claim(JwtClaimTypes.Name, user.UserName),
                        new Claim(JwtClaimTypes.IdentityProvider, "idsvr"),
                        new Claim(JwtClaimTypes.AuthenticationTime, DateTime.UtcNow.ToEpochTime().ToString()),
                    };
                    var ci = new ClaimsIdentity(claims, "password", JwtClaimTypes.Name, JwtClaimTypes.Role);
                    var cp = new ClaimsPrincipal(ci);

                    await HttpContext.Authentication.SignInAsync(Constants.PrimaryAuthenticationType, cp);

                    if (model.SignInId != null)
                    {
                        return new SignInResult(model.SignInId);
                    }

                    return Redirect("~/");
                }

                ModelState.AddModelError("", "Invalid username or password.");
            }

            var vm = new LoginViewModel(model);
            return View(vm);
        }
    }
}

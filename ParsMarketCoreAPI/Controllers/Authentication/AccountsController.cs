using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Models;
using Microsoft.AspNetCore.Identity;
using ViewModels;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;
using AutoMapper;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace ParsMarketCoreAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<Person> _UserManager;
        private readonly RoleManager<Roles> _RoleManager;
        private readonly SignInManager<Person> _SignInManager;
        private IUserService _userService;

        public AccountsController
        (IUserService UserService, UserManager<Person> userManager, RoleManager<Roles> roleManager, SignInManager<Person> signInManager, IConfiguration configuration)
        {
            _userService = UserService;
            _UserManager = userManager;
            _RoleManager = roleManager;
            _SignInManager = signInManager;
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        //[HttpPost("signin")]
        //public async Task<IActionResult> SignIn(LoginViewModel loginViewModel)
        //{
        //    var user = await _UserManager.FindByEmailAsync(loginViewModel.EmailAddress);
        //    if (user == null)
        //    {
        //    }

        //    var isAuth = await _SignInManager.PasswordSignInAsync(user, loginViewModel.Password, loginViewModel.RememberMe, false);
        //    if (isAuth.Succeeded)
        //    {
        //        var userRoles = await _UserManager.GetRolesAsync(user);
        //        var authClaims = new List<Claim>
        //            {
        //               // new Claim(ClaimTypes.Name,),
        //                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //            };
        //        foreach (var role in userRoles)
        //        {
        //            authClaims.Add(new Claim(ClaimTypes.Role, role));
        //        }
        //        var authSighinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection(key: "JWT").GetSection(key: "SecurityKey").Value));
        //        var token = new JwtSecurityToken(
        //        issuer: Configuration.GetSection(key: "JWT").GetSection(key: "ValidIssuer").Value,
        //        audience: Configuration.GetSection(key: "JWT").GetSection(key: "ValidAudience").Value,
        //        expires: DateTime.Now.AddHours(2),
        //        claims: authClaims,
        //        signingCredentials: new SigningCredentials(authSighinKey, SecurityAlgorithms.HmacSha256)
        //        );
        //        return Ok(new
        //        {
        //            token = new JwtSecurityTokenHandler().WriteToken(token),
        //            expireDate = DateTime.Now.AddHours(2)
        //        });
        //    }
        //    return Unauthorized();
        //}

        #region Register User

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                var res = await _userService.RegisterUser(register);
                switch (res)
                {
                    case RegisterUserResult.EmailExist:
                        return JsonResponseStatus.Error(returnData:new { status="EmailExist"});

                }
            }


            return JsonResponseStatus.Success();

        }

        #endregion
        #region Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login()
        {

            return JsonResponseStatus.Success();
        }
        #endregion
    }
}

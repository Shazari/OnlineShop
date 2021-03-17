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
using Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication;

namespace ParsMarketCoreAPI
{

    [ApiController]
    [Route("[controller]")]
    public class AccountsController : BaseApiController
    {
        private readonly UserManager<IdentityUser> _UserManager;
        private readonly RoleManager<IdentityRole> _RoleManager;
        private readonly SignInManager<IdentityUser> _SignInManager;
        private IUserService _userService;

        public AccountsController
        (IUserService UserService, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userService = UserService;
            _UserManager = userManager;
            _RoleManager = roleManager;
            _SignInManager = signInManager;
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        
        
        [HttpPost("signin")]
        public async Task<ActionResult> SignIn([FromBody]LoginViewModel loginViewModel)
        {
            var user = await _UserManager.FindByEmailAsync(loginViewModel.Email);
            if (user == null)
            {
                return BadRequest("Not Found");
            }

            var isAuth = await _SignInManager.PasswordSignInAsync(user, loginViewModel.PasswordHash,loginViewModel.RememberMe, false);
            if (isAuth.Succeeded)
            {
                var userRoles = await _UserManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                    {
                       new Claim(ClaimTypes.Name,user.Email),
                       new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };
                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }
                var authSighinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                Configuration.GetSection(key: "JWT").GetSection(key: "SecurityKey").Value));
                var token = new JwtSecurityToken(
                issuer: Configuration.GetSection(key: "JWT").GetSection(key: "ValidIssuer").Value,
                audience: Configuration.GetSection(key: "JWT").GetSection(key: "ValidAudience").Value,
                expires: DateTime.Now.AddHours(2),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSighinKey, SecurityAlgorithms.HmacSha256)
                );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expireDate = DateTime.Now.AddHours(2)
                });
            }
            return Unauthorized();
        }
        [HttpPost("Create")]
        public async Task<ActionResult> CreateAsync(RegisterViewModel model) 
        {
            var user = new User
            {
                Address = model.Street_Number,
                Email = model.Email,
               
                FirstName = model.FirstName,
                LastName = model.LastName,
                City = model.City,
                IsActive = false,
                IsAdmin = false,
                PhoneNumber = model.PhoneNumber,
                PostCode = model.PostCode,
                UserName = model.Email,
                EmailConfirmed=true,
                LockoutEnabled=true,
                AccessFailedCount=5,
                Countries=model.Countries,
                PhoneNumberConfirmed=true,
                TwoFactorEnabled=false

            };
            var result = await _UserManager.CreateAsync(user,model.Password);
            if (result.Succeeded)
            {
                return Ok("User Created a Account");

            }
            return BadRequest("inValid Data");
        }

        #region Register User

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                //var user = new IdentityUser {UserName=register.EmailAddress,Email=register.EmailAddress};
                // var res = await _UserManager.CreateAsync(user,register.Password);
                // if (!res.Succeeded)
                //{
                //    return JsonResponseStatus.Error(returnData: new { status = "Invalid Data" });
                //}
                var res = await _userService.RegisterUser(register);
                switch (res)
                {
                    case RegisterUserResult.EmailExist:
                        return JsonResponseStatus.Error(returnData: new { status = "EmailExist" });

                }
            }


            return JsonResponseStatus.Success(returnData:new { status="Register Succeeded"});

        }

        #endregion
        #region Login
        [HttpPost("Login")]
        public async Task<IActionResult> PostUser([FromBody]LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var res = await _userService.LoginUser(login);
                switch (res)
                {
                    case LoginUserResult.IncorrectData:
                        return JsonResponseStatus.NotFound();

                    case LoginUserResult.NotActivated:
                        return JsonResponseStatus.Error(new { message = Resources.ErrorMessages.UserNotActivated });

                    case LoginUserResult.Success:
                        var user = await _userService.GetPersonByEmail(login.Email);
                        var secretKy = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection(key: "JWT").GetSection(key: "SecurityKey").Value));
                        var signingCredentials = new SigningCredentials(secretKy, SecurityAlgorithms.HmacSha256);
                        var tokenOptions = new JwtSecurityToken
                            (
                            issuer: Configuration.GetSection(key: "JWT").GetSection(key: "ValidIssuer").Value,
                            claims: new List<Claim>
                            {
                                new Claim(ClaimTypes.Name,user.EmailAddress),
                                 
                                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),

                            },
                            expires: DateTime.Now.AddDays(20),
                            signingCredentials: signingCredentials

                            );
                        var tokenstring = new JwtSecurityTokenHandler().WriteToken(tokenOptions);


                        return JsonResponseStatus.Success(new { token = tokenstring, expireTime = 30, firstName = user.FirstName, lastName = user.LastName, userId = user.Id });

                }
            }
            return JsonResponseStatus.Error();
        }
        #endregion
        #region LogOut
        [HttpGet("SignOut")]
        public async Task<IActionResult> LogOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();
                return JsonResponseStatus.Success();
            }
            return JsonResponseStatus.Success();
        }
        #endregion
    }
}

using System.Security.Claims;
using AuthExample.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthExample.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase{
        [HttpGet("Public")]
        public IActionResult Public(){
            return Ok("Hi, you're on public property");
        }

        private UserModel GetCurrentUser(){
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null){
                var userClaims = identity.Claims;

                return new UserModel{
                    Username = userClaims.FirstOrDefault(i => i.Type == ClaimTypes.NameIdentifier)?.Value,
                    EmailAddress = userClaims.FirstOrDefault(i => i.Type == ClaimTypes.Email)?.Value,
                    GivenName = userClaims.FirstOrDefault(i => i.Type == ClaimTypes.GivenName)?.Value,
                    Surname = userClaims.FirstOrDefault(i => i.Type == ClaimTypes.Surname)?.Value,
                    Role = userClaims.FirstOrDefault(i => i.Type == ClaimTypes.Role)?.Value
                };
            }

            return null;
        }

        [HttpGet("Admins")]
        [Authorize(Roles = "Administrator")]
        public IActionResult AdminsEndpoint(){
            var currentUser = GetCurrentUser();

            return Ok($"Hi {currentUser.GivenName}, You are an {currentUser.Role}");
        }
    }
}
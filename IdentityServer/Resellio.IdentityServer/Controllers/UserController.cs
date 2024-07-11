using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Resellio.IdentityServer.Dtos;
using Resellio.IdentityServer.Models;
using Resellio.Shared.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace Resellio.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Signup(SignupDto signupDto)
        {
            var user = new ApplicationUser
            {
                Name = signupDto.Name,
                Surname = signupDto.Surname,
                UserName = signupDto.Name.ToLower() + signupDto.Surname.ToLower(),
                Email = signupDto.Email            
            };

            var result = await _userManager.CreateAsync(user, signupDto.Password);

            if (!result.Succeeded)
                return BadRequest(Response<NoContent>.Fail(result.Errors.Select(x=>x.Description).ToList(), 400));

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);

            if (userIdClaim == null)
                return BadRequest();

            var user = await _userManager.FindByIdAsync(userIdClaim.Value);

            if (user == null)
                return BadRequest();

            return Ok(new { Id = user.Id, Name = user.Name, Surname = user.Surname, Email = user.Email, Picture = user.Picture });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserUpdateDto userUpdateDto)
        {
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);

            if (userIdClaim == null)
                return BadRequest();

            var user = await _userManager.FindByIdAsync(userIdClaim.Value);

            if (user == null)
                return BadRequest();

            user.Name = userUpdateDto.Name;
            user.Surname = userUpdateDto.Surname;
            user.Email = userUpdateDto.Email;
            user.Picture = userUpdateDto.Picture;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                return BadRequest(Response<NoContent>.Fail(result.Errors.Select(x => x.Description).ToList(), 400));

            return NoContent();
        }
    }
}

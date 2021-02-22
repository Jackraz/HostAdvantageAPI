using HostAdvantageAPI.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostAdvantageAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly HostAdvantageContext _context;

        public LoginController(HostAdvantageContext context)
        {
            _context = context;
        }

        // POST: api/login
        [HttpPost]
        public async Task<ActionResult<User>> Login(User queryUser)
        {
            //if (string.IsNullOrEmpty(queryUser.UserName)|| string.IsNullOrEmpty(queryUser.Password))
            if(!ModelState.IsValid)
                return BadRequest();

            //var storedUser = await _context.User.FindAsync(queryUser.UserName);
            var storedUser = _context.User.Where(x => x.UserName == queryUser.UserName).FirstOrDefault<User>();

            if (storedUser == null)
            {
                return NotFound();
            }
            if (storedUser.Password != queryUser.Password && storedUser.UserName == queryUser.UserName)
            {
                return Unauthorized();
            }
            else { 
                return storedUser;
            }
            //return CreatedAtAction(nameof(UserController.GetUser), new { id = storedUser.Id }, storedUser);
        }

    }
}

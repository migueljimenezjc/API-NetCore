using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.App_Code;
using API.Core.Interfaces;
using API.Entities.Entities;
using API.Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDataRepository<User> _dataRepository;
        public UsersController(IDataRepository<User> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Receipt
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string email, string password)
        {
            User user = new User();
            SessionAPI session = new SessionAPI();
            try
            {
                user = _dataRepository.Get(email, password);
                if(user == null)
                    return StatusCode(202, "Unable to process request");

                session.Email = email;
                session.Name = user.username;
                session.Token = TokenAPI.GetToken(user.id.ToString());
                return Ok(session);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Unable to process request");
            }
        }


    }
}
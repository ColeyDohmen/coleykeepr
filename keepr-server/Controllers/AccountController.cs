using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using keeprcoley.Models;
using keeprcoley.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly ProfilesService _ps;
        // private readonly ReviewsService _reviewserv;

        public AccountController(ProfilesService ps)
        {
            _ps = ps;
        }

        [HttpGet]
        public async Task<ActionResult<Profile>> Get()
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_ps.GetOrCreateProfile(userInfo));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // [HttpGet("vaults")]
        // public async Task<ActionResult<IEnumerable<Vault>>> GetVaultsByAccountId()
        // {
        //     try
        //     {
        //         Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        //         return Ok(_serv.GetReviewsByAccountId(userInfo.Id));
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }
    }
}
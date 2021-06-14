using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using keepr_server.Models;
using keepr_server.Services;
using keeprcoley.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaultKeepsController : ControllerBase
    {
        private readonly VaultKeepsService _vkserv;

        public VaultKeepsController(VaultKeepsService vkserv)
        {
            _vkserv = vkserv;
        }

        ///<summary>
        ///Makes a new vault-keep, makes sure the user is logged in and authenticated with Auth0.
        ///</summary>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<VaultKeep>> Post([FromBody] VaultKeep newVaultKeep)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newVaultKeep.CreatorId = userInfo.Id;
                return Ok(_vkserv.Create(newVaultKeep));

            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }
        }

        ///<summary>
        ///Deletes vault-keep by id, makes sure the user is logged in and authenticated with Auth0.
        ///</summary>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<string>> DeleteAsync(int id)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                _vkserv.Delete(id, userInfo.Id);
                return Ok("Deleted");

            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

    }
}
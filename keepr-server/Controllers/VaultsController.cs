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
    public class VaultsController : ControllerBase
    {
        private readonly VaultsService _vserv;

        public VaultsController(VaultsService vserv)
        {
            _vserv = vserv;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Vault>> Get()
        {
            try
            {
                return Ok(_vserv.GetAll());
            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Vault>>> GetAsync(int id)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_vserv.Get(id, userInfo));
            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Vault>> Post([FromBody] Vault newVault)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newVault.CreatorId = userInfo.Id;
                Vault created = _vserv.Create(newVault);
                created.Creator = userInfo;
                return Ok(created);
            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Vault>> Edit(int id, [FromBody] Vault editData)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                editData.Id = id;
                editData.Creator = userInfo;
                editData.CreatorId = userInfo.Id;
                return Ok(_vserv.Edit(editData, userInfo.Id));
            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_vserv.Delete(id, userInfo.Id));
            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}/keeps")]
        public async Task<ActionResult<IEnumerable<VaultKeepViewModel>>> GetKeepsAsync(int id)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_vserv.GetByVaultId(id, userInfo));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using keepr_server.Models;
using keepr_server.Services;
using keeprcoley.Models;
using keeprcoley.Services;
using Microsoft.AspNetCore.Mvc;

namespace keepr_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly ProfilesService _service;
        private readonly KeepsService _kserv;
        private readonly VaultsService _vserv;

        public ProfilesController(ProfilesService service, KeepsService kserv, VaultsService vserv)
        {
            _service = service;
            _kserv = kserv;
            _vserv = vserv;
        }

        [HttpGet("{id}")]
        public ActionResult<Profile> Get(string id)
        {
            try
            {
                Profile profile = _service.GetProfileById(id);
                return Ok(profile);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/keeps")]
        public ActionResult<IEnumerable<VaultKeepViewModel>> GetKeeps(string id)
        {
            try
            {
                return Ok(_kserv.GetByProfileId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/vaults")]
        public ActionResult<IEnumerable<Vault>> GetVaults(string id)
        {
            try
            {
                return Ok(_vserv.GetByProfileId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
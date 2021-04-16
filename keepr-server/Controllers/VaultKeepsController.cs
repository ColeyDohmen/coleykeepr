using System;
using System.Collections.Generic;
using keepr_server.Models;
using keepr_server.Services;
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

        [HttpGet]
        public ActionResult<IEnumerable<VaultKeep>> Get()
        {
            try
            {
                return Ok(_vkserv.GetAll());
            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }
        }
    }
}
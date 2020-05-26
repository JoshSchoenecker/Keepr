using System;
using System.Security.Claims;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class VaultKeepController : ControllerBase
    {
        private readonly VaultKeepService _vks;
        public VaultKeepController(VaultKeepService vks)
        {
            _vks = vks;
        }

        // NOTE Post Request
        [HttpPost]
        public ActionResult<VaultKeep> Create([FromBody] VaultKeep newVaultKeep)
        {
            try
            {
                return Ok(_vks.Create(newVaultKeep));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // NOTE Get Requests
        [HttpGet("{id}")]
        public ActionResult<VaultKeep> GetVaultKeepById(int id)
        {
            try
            {
                return Ok(_vks.GetVaultKeepById(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // NOTE Delete Request
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (user == null)
                {
                    throw new Exception("You must log in to delete");
                }
                string userId = user.Value;
                return Ok(_vks.Delete(id, userId));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
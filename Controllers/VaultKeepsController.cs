using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class VaultKeepsController : ControllerBase
    {
        private readonly VaultKeepsService _vks;
        public VaultKeepsController(VaultKeepsService vks)
        {
            _vks = vks;
        }

        // NOTE Post Request
        [HttpPost]
        public ActionResult<VaultKeep> Create([FromBody] VaultKeep newVaultKeep)
        {
            try
            {
                 Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                 if (user == null)
                 {
                     throw new Exception("invalid id");
                 }
                 string userId = user.Value;
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
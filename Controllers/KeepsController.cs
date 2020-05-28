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
    public class KeepsController : ControllerBase
    {
        private readonly KeepsService _ks;
        public KeepsController(KeepsService ks)
        {
            _ks = ks;
        }

        // NOTE Post Request
        [HttpPost]
        [Authorize]
        public ActionResult<Keep> Post([FromBody] Keep newKeep)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                newKeep.UserId = userId;
                return Ok(_ks.Create(newKeep));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // NOTE Get Requests
        [HttpGet]
        public ActionResult<IEnumerable<Keep>> GetPublicKeeps()
        {
            try
            {
                return Ok(_ks.GetPublicKeeps());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            };
        }
        [HttpGet("{id}")]
        public ActionResult<Keep> GetKeepById(int id)
        {
            try
            {
                return Ok(_ks.GetKeepById(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [Authorize]
        [HttpGet("user")]
        public ActionResult<IEnumerable<Keep>> GetKeepsByUser()
        {
            try
            {
                Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (user == null)
                {
                    throw new Exception("Please Log in to view your keeps :)");
                }
                string userId = user.Value;
                return Ok(_ks.GetKeepsByUser(userId));
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
                return Ok(_ks.Delete(id, userId));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // NOTE Put Request
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<Keep> Edit(int id, [FromBody] Keep keepToUpdate){
            try
            {
                keepToUpdate.Id = id;
                Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (user == null)
                {
                    throw new Exception("Please Login");
                }
                string userId = user.Value;
                return Ok(_ks.Edit(keepToUpdate, userId));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);                
            }
        }

        // [Authorize]
        // [HttpPut("{id}")]
        // public ActionResult<Keep> toggleIsPrivate(int id, [FromBody] Keep keepToUpdate)
        // {
        //     try
        //     {
        //         keepToUpdate.Id = id;
        //         Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        //         if (user == null)
        //         {
        //             throw new Exception("You must log in to change this");
        //         }
        //         string userId = user.Value;
        //         return Ok(_ks.toggleIsPrivate(keepToUpdate, userId));
        //     }
        //     catch (System.Exception err)
        //     {
        //         return BadRequest(err.Message);
        //     }
        // }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MediatrPattern.Domain.Users.Commands.Insert;
using MediatrPattern.Domain.Users.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatrPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediatr;
        private readonly IRead _read;

        public UserController(IMediator mediatr, IRead read)
        {
            _mediatr = mediatr;
            _read = read;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await this._read.List();

            return Ok(new { dados = user });
        }

        [HttpPost]
        public async Task<IActionResult> Post(Request user)
        {
            var result = await _mediatr.Send(user);

            return Ok(new { dados = result });
        }
    }
}
using HospitalManagment_V2.Mediator.Users.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagment_V2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            var user = await _mediator.Send(command);
            return Ok(user);
        }
    }
}

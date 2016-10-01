using DN.UserControlApp.Domain.Account.Commands;
using DN.UserControlApp.Domain.Account.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DN.UserControlApp.API.Controllers
{
    [RoutePrefix("api/v1/public/users")]
    public class AccountController : BaseController
    {
        private IUserApplicationService _service;

        public AccountController(IUserApplicationService service)
        {
            _service = service;
        }


        [HttpPost]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new RegisterUserCommand(
                firstName: (string)body.firstName,
                email: (string)body.username,
                password: (string)body.password
            );

            _service.Register(command);

            return CreateResponse(HttpStatusCode.OK, command);
        }


    }
}

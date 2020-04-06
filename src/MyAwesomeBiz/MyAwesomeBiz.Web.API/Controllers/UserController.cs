using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyAwesomeBiz.Application;
using MyAwesomeBiz.Domain;

namespace MyAwesomeBiz.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserApplication _app;

        public UserController(IUserApplication application)
        {
            _app = application;
        }

        [HttpPost]
        public async Task<ActionResult<User>>Post(User model)
        {
            return await _app.Save(model);
        }

        [HttpPut]
        public async Task<ActionResult<User>>Put(User model)
        {
            return await _app.Update(model);
        }

        [HttpGet("{fullName}")]
        public async Task<ActionResult<User>>Get(string fullName)
        {
            return await _app.GetUserByFullName(fullName);
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>>Get()
        {
            return await _app.ReadAll();
        }
    }
}
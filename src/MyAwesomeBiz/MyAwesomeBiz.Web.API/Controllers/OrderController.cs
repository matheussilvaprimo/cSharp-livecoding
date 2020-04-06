using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyAwesomeBiz.Application;
using MyAwesomeBiz.Domain;

namespace MyAwesomeBiz.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderApplication _app;

        public OrderController(IOrderApplication app)
        {
            _app = app;   
        }

        [HttpPost]
        public async Task<ActionResult<Order>>Post(Order model)
        {
            return await _app.Save(model);
        }

        [HttpPut]
        public async Task<ActionResult<Order>>Put(Order model)
        {
            return await _app.Update(model);
        }

        [HttpGet("{userName}")]
        public async Task<ActionResult<List<Order>>>Get(string userName)
        {
            return await _app.FindOrdersByUserName(userName);
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>>Get()
        {
            return await _app.ReadAll();
        }
    }
}
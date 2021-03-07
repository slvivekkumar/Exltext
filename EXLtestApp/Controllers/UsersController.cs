using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbModel.Model;
using EXLtestApp.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EXLtestApp.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            using (var unitofwork = new UnitOfWork(new AppDBContext()))
            {
                return unitofwork.Users.GetAll();
            }

        }

        [HttpGet("{id}")]

        public User Get(int Id)
        {
            using (var unitofwork = new UnitOfWork(new AppDBContext()))
            {
                return unitofwork.Users.Get(Id);
            }

        }

        [HttpGet("GetSearchUsers/{criteria?}/{empstartdate?}/{empenddate?}")]
        public IEnumerable<User> GetSearchUsers(string? criteria, DateTime? empstartdate, DateTime? empenddate)
        {
            var unitofwork = new UnitOfWork(new AppDBContext());

            return unitofwork.Users.GetSearchUsers(criteria, empstartdate, empenddate);

        }

        [HttpPost]
        public void Add(User user)
        {
            using (var unitofwork = new UnitOfWork(new AppDBContext()))
            {
                unitofwork.Users.Add(user);
                unitofwork.Complete();
            }

        }
    }
}

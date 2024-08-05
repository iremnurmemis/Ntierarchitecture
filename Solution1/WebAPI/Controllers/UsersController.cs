using Business;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace RentACarWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

      


        /// <summary>
        /// Bu API sayesinde müşteri ekleyebilirsiniz.
        /// </summary>
        /// <returns></returns>
        [HttpPost("Add")]
        public void Add(User user)
        {
             _userService.Add(user);
           
        }

   




    }
}
using Microsoft.AspNetCore.Mvc;
using API_Computacion_Movil_Luis.Models;

namespace API_Computacion_Movil_Luis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private static List<User> users = new List<User>()
        {
            new User { Id = 1, Name = "Luis", Email = "luis@gmail.com" }
        };

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return users;
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);

            if (user == null)
                return NotFound();

            return user;
        }

        [HttpPost]
        public ActionResult<User> Post(User user)
        {
            user.Id = users.Count + 1;

            users.Add(user);

            return user;
        }

        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, User updatedUser)
        {
            var user = users.FirstOrDefault(u => u.Id == id);

            if (user == null)
                return NotFound();

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;

            return user;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);

            if (user == null)
                return NotFound();

            users.Remove(user);

            return NoContent();
        }
    }
}
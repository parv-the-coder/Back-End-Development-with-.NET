[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    [HttpGet]
    public IActionResult GetUsers() => Ok(UserRepository.GetAll());

    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        var user = UserRepository.GetById(id);
        if (user == null) return NotFound(new { error = "User not found." });
        return Ok(user);
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] User user)
    {
        if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email))
            return BadRequest(new { error = "Invalid user data." });
        
        UserRepository.Add(user);
        return Created($"api/users/{user.Id}", user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] User user)
    {
        var existingUser = UserRepository.GetById(id);
        if (existingUser == null) return NotFound(new { error = "User not found." });

        user.Id = id;
        UserRepository.Update(user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        if (UserRepository.GetById(id) == null) return NotFound(new { error = "User not found." });
        UserRepository.Delete(id);
        return NoContent();
    }
}
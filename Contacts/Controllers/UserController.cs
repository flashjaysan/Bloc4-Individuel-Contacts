using Contacts.Business;
using Contacts.Common.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.API.Controllers;

[Produces("application/json")]
[Route("api/users")]
public class UserController : Controller
{
    private readonly IService<UserResource> _userService;

    public UserController(IService<UserResource> userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public async Task<UserResource> GetItemById(int id)
    {
        return await _userService.GetItemById(id);
    }

    [HttpGet]
    public async Task<List<UserResource>> GetAll()
    {
        return await _userService.GetAll();
    }

    [HttpPost]
    public async Task<UserResource> Add([FromBody] UserResource userResource)
    {
        return await _userService.Add(userResource);
    }

    [HttpPut]
    public async Task<UserResource> Update([FromBody] UserResource userResource)
    {
        return await _userService.Update(userResource);
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await _userService.Delete(id);
    }
}

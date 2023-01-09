using Contacts.Business;
using Contacts.Common.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.API.Controllers;

[Produces("application/json")]
[Route("api/roles")]
public class RoleController : Controller
{
    private readonly IService<RoleResource> _roleService;

    public RoleController(IService<RoleResource> roleService)
    {
        _roleService = roleService;
    }

    [HttpGet("{id}")]
    public async Task<RoleResource> GetItemById(int id)
    {
        return await _roleService.GetItemById(id);
    }

    [HttpGet]
    public async Task<List<RoleResource>> GetAll()
    {
        return await _roleService.GetAll();
    }

    [HttpPost]
    public async Task<RoleResource> Add([FromBody] RoleResource roleResource)
    {
        return await _roleService.Add(roleResource);
    }

    [HttpPut]
    public async Task<RoleResource> Update([FromBody] RoleResource roleResource)
    {
        return await _roleService.Update(roleResource);
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await _roleService.Delete(id);
    }
}

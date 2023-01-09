using Contacts.Business;
using Contacts.Common.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.API.Controllers;

[Produces("application/json")]
[Route("api/places")]
public class PlaceController : Controller
{
    private readonly IService<PlaceResource> _roleService;

    public PlaceController(IService<PlaceResource> roleService)
    {
        _roleService = roleService;
    }

    [HttpGet("{id}")]
    public async Task<PlaceResource> GetItemById(int id)
    {
        return await _roleService.GetItemById(id);
    }

    [HttpGet]
    public async Task<List<PlaceResource>> GetAll()
    {
        return await _roleService.GetAll();
    }

    [HttpPost]
    public async Task<PlaceResource> Add([FromBody] PlaceResource roleResource)
    {
        return await _roleService.Add(roleResource);
    }

    [HttpPut]
    public async Task<PlaceResource> Update([FromBody] PlaceResource roleResource)
    {
        return await _roleService.Update(roleResource);
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await _roleService.Delete(id);
    }
}

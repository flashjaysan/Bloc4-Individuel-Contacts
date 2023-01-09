using Contacts.Business;
using Contacts.Common.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.API.Controllers;

[Produces("application/json")]
[Route("api/departments")]
public class DepartmentController : Controller
{
    private readonly IService<DepartmentResource> _roleService;
    
    public DepartmentController(IService<DepartmentResource> roleService)
    {
        _roleService = roleService;
    }

    [HttpGet("{id}")]
    public async Task<DepartmentResource> GetItemById(int id)
    {
        return await _roleService.GetItemById(id);
    }

    [HttpGet]
    public async Task<List<DepartmentResource>> GetAll()
    {
        return await _roleService.GetAll();
    }

    [HttpPost]
    public async Task<DepartmentResource> Add([FromBody] DepartmentResource roleResource)
    {
        return await _roleService.Add(roleResource);
    }

    [HttpPut]
    public async Task<DepartmentResource> Update([FromBody] DepartmentResource roleResource)
    {
        return await _roleService.Update(roleResource);
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await _roleService.Delete(id);
    }
}

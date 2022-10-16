using EndavaGrowthSpace.BLL.Interfaces;
using EndavaGrowthSpace.BLL.Models.Modules;
using EndavaGrowthSpace.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EndavaGrowthSpace.Controllers;

[ApiController]
public class ModulesController : ControllerBase
{
    private readonly IModuleService _moduleService;

    public ModulesController(IModuleService moduleService)
    {
        _moduleService = moduleService;
    }

    [HttpPost]
    public IActionResult Add(CreateModuleDto createModuleDto)
    {
        return StatusCode(201, _moduleService.Add(createModuleDto));
    }

    [HttpGet("{id}")]
    public ActionResult<Module> GetById(int id)
    {
        return _moduleService.GetById(id);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteById(int id)
    {
        _moduleService.Delete(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult<Module> Update(UpdateModuleDto updateModuleDto, int id)
    {
        return _moduleService.Update(updateModuleDto, id);
    }
}
using EndavaGrowthSpace.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EndavaGrowthSpace.Controllers;

[ApiController]
public class ModuleController : ControllerBase
{
    private readonly IModuleService _moduleService;

    public ModuleController(IModuleService moduleService)
    {
        _moduleService = moduleService;
    }
    
    
    
}
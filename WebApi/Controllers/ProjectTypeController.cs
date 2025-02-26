using Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTypeController(IProjectTypeService projectTypeService) : ControllerBase
    {
        private readonly IProjectTypeService _ProjectTypeService = projectTypeService;

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var projectTypes = await _ProjectTypeService.GetProjectTypeAsync();
            return Ok(projectTypes);
        }
    }
}

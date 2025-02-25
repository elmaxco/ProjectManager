using Business.Dtos;
using Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController(IProjectService projectService) : ControllerBase
{
    private readonly IProjectService _projectService = projectService;

    [HttpPost]
    public async Task<IActionResult> Create(ProjectRegistarationForm form) 
    {
        if (!ModelState.IsValid && form.CustomerId < 1)
            return BadRequest();

        var result = await _projectService.CreateProjectAsync(form);
        return result ? Created("", null) : Problem();

    }
    [HttpPost]
    public async Task<IActionResult> GetAll()
    {
        var projects = await _projectService.GetProjectsAsync();
        return Ok(projects);
    }
}

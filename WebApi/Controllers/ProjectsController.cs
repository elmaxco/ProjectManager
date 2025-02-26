using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ProjectsController(IProjectService projectService) : ControllerBase
{
    private readonly IProjectService _projectService = projectService;

    [HttpPost]

    public async Task<IActionResult> CreateProject(ProjectRegistarationForm form)
    {
        if (!ModelState.IsValid && form.CustomerId < 1)
            return BadRequest(ModelState);

        var project = await _projectService.CreateProjectAsync(form);
        return project == null ? BadRequest() : Ok(project);

    }

    [HttpGet]
    public async Task<IActionResult> GetProjects()
    {
       var projects = await _projectService.GetProjectsAsync();
        return Ok(projects);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProject(int id)
    {
        var projects = await _projectService.GetProjectsAsync(id);
        return projects != null ? Ok(projects) : NotFound();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProject(Project project)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _projectService.UpdateProjectAsync(project);
        return result ? Ok() : BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        var project = await _projectService.GetProjectsAsync(id);

        if (project == null)
            return NotFound();

        var result = await _projectService.DeleteProjectAsync(project);
        return result ? Ok() : BadRequest();
    }




}
   

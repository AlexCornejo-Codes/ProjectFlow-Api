using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectFlow.Api.Database;
using ProjectFlow.Api.DTOs.Projects;
using ProjectFlow.Api.Entities;

namespace ProjectFlow.Api.Controllers;

[ApiController]
[Route("projects")]
public sealed class ProjectsController(ApplicationDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ProjectsCollectionDto>> GetProjects()
    {
        List<ProjectDto> projects = await dbContext
            .Projects
            .Select(p => new ProjectDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                ClientName = p.ClientName,
                Status = p.Status,
                Priority = p.Priority,
                Target = new TargetDto
                {
                    Value = p.Target.Value,
                    Unit = p.Target.Unit
                },
                IsArchived = p.IsArchived,
                EndDate = p.EndDate,
                Milestone = p.Milestone == null ? null : new MilestoneDto
                {
                    Target = p.Target.Value,
                    Current = p.Milestone.Current
                },
                CreatedAtUtc = p.CreatedAtUtc,
                UpdatedAtUtc = p.UpdatedAtUtc,
                LastCompletedAtUtc = p.LastCompletedAtUtc
            })
            .ToListAsync();

        var projectsCollectionDto = new ProjectsCollectionDto
        {
            Data = projects
        };
        
        return Ok(projectsCollectionDto);
    }
    
    [HttpGet("{Id}")]
    public async Task<ActionResult<ProjectDto>> GetProject(string Id)
    {
        ProjectDto? project = await dbContext
            .Projects
            .Where(p => p.Id == Id)
            .Select(p => new ProjectDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                ClientName = p.ClientName,
                Status = p.Status,
                Priority = p.Priority,
                Target = new TargetDto
                {
                    Value = p.Target.Value,
                    Unit = p.Target.Unit
                },
                IsArchived = p.IsArchived,
                EndDate = p.EndDate,
                Milestone = p.Milestone == null ? null : new MilestoneDto
                {
                    Target = p.Target.Value,
                    Current = p.Milestone.Current
                },
                CreatedAtUtc = p.CreatedAtUtc,
                UpdatedAtUtc = p.UpdatedAtUtc,
                LastCompletedAtUtc = p.LastCompletedAtUtc
            })
            .FirstOrDefaultAsync();

        if (project is null)
        {
            return NotFound();
        }

        return Ok(project);
    }
}

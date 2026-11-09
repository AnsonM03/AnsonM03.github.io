using Microsoft.EntityFrameworkCore;
using Portfolio.Api.Data;
using Portfolio.Api.Dtos;
using Portfolio.Api.Models;

namespace Portfolio.Api.Services;

public class ProjectService
{
    private readonly PortfolioDbContext _context;

    public ProjectService(PortfolioDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProjectDto>> GetAllAsync()
    {
        var projects = await _context.Projects
            .AsNoTracking()
            .OrderBy(project => project.Id)
            .ToListAsync();

        return projects
            .Select(ToDto)
            .ToList();
    }

    public async Task<ProjectDto?> GetByIdAsync(int id)
    {
        var project = await _context.Projects
            .AsNoTracking()
            .FirstOrDefaultAsync(project => project.Id == id);

        if (project is null)
        {
            return null;
        }

        return ToDto(project);
    }

    public async Task<ProjectDto> CreateAsync(ProjectInputDto input)
    {
        var project = new Project();

        ApplyInput(project, input);

        _context.Projects.Add(project);
        await _context.SaveChangesAsync();

        return ToDto(project);
    }

    public async Task<bool> UpdateAsync(int id, ProjectInputDto input)
    {
        var project = await _context.Projects.FindAsync(id);

        if (project is null)
        {
            return false;
        }

        ApplyInput(project, input);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var project = await _context.Projects.FindAsync(id);

        if (project is null)
        {
            return false;
        }

        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();

        return true;
    }

    private static ProjectDto ToDto(Project project)
    {
        return new ProjectDto
        {
            Id = project.Id,
            Titel = project.Titel,
            Beschrijving = project.Beschrijving,
            Categorie = project.Categorie,
            GitHubUrl = project.GitHubUrl,
            Datum = project.Datum
        };
    }

    private static void ApplyInput(
        Project project,
        ProjectInputDto input)
    {
        var datum = input.Datum
            ?? throw new ArgumentException(
                "Een datum is verplicht.",
                nameof(input)
            );

        project.Titel = input.Titel;
        project.Beschrijving = input.Beschrijving;
        project.Categorie = input.Categorie;
        project.GitHubUrl = input.GitHubUrl;
        project.Datum = datum;
    }
}
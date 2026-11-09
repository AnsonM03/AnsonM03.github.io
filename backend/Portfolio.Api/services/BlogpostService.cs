using Microsoft.EntityFrameworkCore;
using Portfolio.Api.Data;
using Portfolio.Api.Dtos;
using Portfolio.Api.Models;

namespace Portfolio.Api.Services;

public class BlogpostService
{
    private readonly PortfolioDbContext _context;

    public BlogpostService(PortfolioDbContext context)
    {
        _context = context;
    }

    public async Task<List<BlogpostDto>> GetAllAsync()
    {
        var blogposts = await _context.Blogposts
            .AsNoTracking()
            .OrderByDescending(blogpost => blogpost.Publicatiedatum)
            .ThenBy(blogpost => blogpost.Id)
            .ToListAsync();

        return blogposts
            .Select(ToDto)
            .ToList();
    }

    public async Task<BlogpostDto?> GetByIdAsync(int id)
    {
        var blogpost = await _context.Blogposts
            .AsNoTracking()
            .FirstOrDefaultAsync(blogpost => blogpost.Id == id);

        if (blogpost is null)
        {
            return null;
        }

        return ToDto(blogpost);
    }

    public async Task<BlogpostDto> CreateAsync(BlogpostInputDto input)
    {
        var blogpost = new Blogpost();

        ApplyInput(blogpost, input);

        _context.Blogposts.Add(blogpost);
        await _context.SaveChangesAsync();

        return ToDto(blogpost);
    }

    public async Task<bool> UpdateAsync(int id, BlogpostInputDto input)
    {
        var blogpost = await _context.Blogposts.FindAsync(id);

        if (blogpost is null)
        {
            return false;
        }

        ApplyInput(blogpost, input);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var blogpost = await _context.Blogposts.FindAsync(id);

        if (blogpost is null)
        {
            return false;
        }

        _context.Blogposts.Remove(blogpost);
        await _context.SaveChangesAsync();

        return true;
    }

    private static BlogpostDto ToDto(Blogpost blogpost)
    {
        return new BlogpostDto
        {
            Id = blogpost.Id,
            Titel = blogpost.Titel,
            Inhoud = blogpost.Inhoud,
            Publicatiedatum = blogpost.Publicatiedatum
        };
    }

    private static void ApplyInput(
        Blogpost blogpost,
        BlogpostInputDto input)
    {
        var publicatiedatum = input.Publicatiedatum
            ?? throw new ArgumentException(
                "Een publicatiedatum is verplicht.",
                nameof(input)
            );

        blogpost.Titel = input.Titel;
        blogpost.Inhoud = input.Inhoud;
        blogpost.Publicatiedatum = publicatiedatum;
    }
}
using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.Dtos;
using Portfolio.Api.Services;

namespace Portfolio.Api.Controllers;

[ApiController]
[Route("api/blogposts")]
public class BlogpostsController : ControllerBase
{
    private readonly BlogpostService _blogpostService;

    public BlogpostsController(BlogpostService blogpostService)
    {
        _blogpostService = blogpostService;
    }

    [HttpGet]
    public async Task<ActionResult<List<BlogpostDto>>> GetAll()
    {
        var blogposts = await _blogpostService.GetAllAsync();

        return Ok(blogposts);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BlogpostDto>> GetById(int id)
    {
        var blogpost = await _blogpostService.GetByIdAsync(id);

        if (blogpost is null)
        {
            return NotFound();
        }

        return Ok(blogpost);
    }

    [HttpPost]
    public async Task<ActionResult<BlogpostDto>> Create(
        [FromBody] BlogpostInputDto input)
    {
        var blogpost = await _blogpostService.CreateAsync(input);

        return CreatedAtAction(
            nameof(GetById),
            new { id = blogpost.Id },
            blogpost
        );
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] BlogpostInputDto input)
    {
        var updated = await _blogpostService.UpdateAsync(id, input);

        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _blogpostService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
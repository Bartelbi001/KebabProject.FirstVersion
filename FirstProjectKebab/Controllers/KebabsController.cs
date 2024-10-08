using FirstProjectKebab.Contracts;
using KebabStore.Application.Services;
using KebabStore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstProjectKebab.Controllers;

[ApiController]
[Route("[controller]")]
public class KebabsController : ControllerBase
{
    private readonly IKebabsService _kebabsService;

    public KebabsController(IKebabsService kebabsService)
    {
        _kebabsService = kebabsService;
    }

    [HttpGet]
    public async Task<ActionResult<List<KebabsResponse>>> GetKebabs()
    {
        var kebabs = await _kebabsService.GetAllKebabs();

        var response = kebabs.Select(k => new KebabsResponse(k.Id, k.Name, k.Description, k.Price));

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateKebab([FromBody] KebabsRequest request)
    {
        var (kebab, error) = Kebab.Create(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.Price);

        if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }

        var kebabId = await _kebabsService.CreateKebab(kebab);

        return Ok(kebabId);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateKebab(Guid id, [FromBody] KebabsRequest request)
    {
        var kebabId = await _kebabsService.UpdateKebab(id, request.Name, request.Description, request.Price);

        return Ok(kebabId);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> KebabDelete(Guid id)
    {
        return Ok(await _kebabsService.DeleteKebab(id));
    }
}

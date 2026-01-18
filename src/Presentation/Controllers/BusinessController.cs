using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.Dtos;

namespace Presentation.Controllers;

[ApiController]
[Route("api/businesses")]
public class BusinessController(BusinessService businessService) : ControllerBase
{
    [HttpPost("")]
    public async Task<ActionResult<CreateBusinessResponse>> CreateBusiness(CreateBusinessRequest request)
    {
        var businessId = await businessService.CreateBusinessAsync(request.UserId, request.Name);

        // TODO: Come back to this
        return CreatedAtAction(
            nameof(CreateBusiness),
            new { id = businessId },
            new CreateBusinessResponse { BusinessId = businessId }
        );
    }
}
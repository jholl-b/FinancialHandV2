using FinancialHandV2.Application.Income.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialHandV2.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class IncomeController : ControllerBase
{
  private readonly IMediator _mediator;

  public IncomeController(IMediator mediator)
    => _mediator = mediator;

  [HttpGet]
  public IActionResult Get()
  {
    return Ok("OK");
  }

  [HttpPost]
  public async Task<ActionResult<int>> Create(CreateIncomeCommand command)
  {
    var response = await _mediator.Send(command);
    return Ok(command);
  }
}
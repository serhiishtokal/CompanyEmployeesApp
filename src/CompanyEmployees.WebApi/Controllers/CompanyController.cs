using CompanyEmployees.Application.Commands.Companies.Delete;
using CompanyEmployees.Application.Commands.Companies.Update;
using CompanyEmployees.Application.DTOs;
using CompanyEmployees.Application.Queries.Companies.Search;
using CompanyEmployees.Domain.Companies.Exceptions;
using CompanyEmployeesApplication.Commands.Companies.Create;
using CompanyEmployeesApplication.Queries.Companies.Get;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployeesApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly IMediator _mediator;

        public CompanyController(ILogger<CompanyController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]long id)
        {
            try
            {
                var result = await _mediator.Send(new GetCompanyQuery(id));
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] CompanyDto company)
        {
            try
            {
                var result = await _mediator.Send(new AddCompanyCommand(company));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CompanyDto company, long id)
        {
            try
            {
                var result = await _mediator.Send(new UpdateCompanyCommand(id, company));
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteCompanyCommand(id));
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody]CompanyFilterDto filter)
        {
            try
            {
                var result = await _mediator.Send(new SearchCompaniesQuery(filter));
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
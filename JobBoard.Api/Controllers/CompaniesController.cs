using JobBoard.Api.DTOs;
using JobBoard.Api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyService _companyService;
    public CompaniesController(ICompanyService companyService)
    {
        _companyService = companyService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllCompanies()
    {
        var companies = await _companyService.GetAllCompaniesAsync();
        return Ok(companies);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompanyById(Guid id)
    {
        var company = await _companyService.GetCompanyByIdAsync(id);
        if (company == null) return NotFound();
        return Ok(company);
    }
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateCompany(CreateCompanyRequest request)
    {
        var newCompany = await _companyService.CreateCompanyAsync(request);
        return CreatedAtAction(nameof(GetCompanyById), new { id = newCompany.Id }, newCompany);
    }
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCompany(Guid id, CreateCompanyRequest request)
    {
        var success = await _companyService.UpdateCompanyAsync(id, request);
        if (!success) return NotFound();
        return NoContent();
    }
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompany(Guid id)
    {
        var success = await _companyService.DeleteCompanyAsync(id);
        if (!success) return NotFound();
        return NoContent();
    }
}
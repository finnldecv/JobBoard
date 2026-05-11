using JobBoard.Api.Data;
using JobBoard.Api.DTOs;
using JobBoard.Api.Models;
using JobBoard.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobBoard.Api.Services;

public class CompanyService : ICompanyService
{
    private readonly JobBoardDbContext _dbContext;
    public CompanyService(JobBoardDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<CompanyResponse>> GetAllCompaniesAsync()
    {
        return await _dbContext.Companies
                                .Select(c => new CompanyResponse
                                {
                                    Id = c.Id,
                                    Name = c.Name,
                                    WebsiteUrl = c.WebsiteUrl
                                }).ToListAsync();
    }

    public async Task<CompanyResponse?> GetCompanyByIdAsync(Guid id)
    {
        var company = await _dbContext.Companies.FindAsync(id);
        if (company == null) return null;
        return new CompanyResponse
        {
            Id = company.Id,
            Name = company.Name,
            WebsiteUrl = company.WebsiteUrl
        };
    }
    public async Task<CompanyResponse> CreateCompanyAsync(CreateCompanyRequest request)
    {
        var company = new Company
        {
            Name = request.Name,
            WebsiteUrl = request.WebsiteUrl
        };
        _dbContext.Companies.Add(company);
        await _dbContext.SaveChangesAsync();
        return new CompanyResponse
        {
            Id = company.Id,
            Name = company.Name,
            WebsiteUrl = company.WebsiteUrl
        };
    }

    public async Task<bool> UpdateCompanyAsync(Guid id, CreateCompanyRequest request)
    {
        var company = await _dbContext.Companies.FindAsync(id);
        if (company == null) return false;
        company.Name = request.Name;
        company.WebsiteUrl = request.WebsiteUrl;
        await _dbContext.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteCompanyAsync(Guid id)
    {
        var company = await _dbContext.Companies.FindAsync(id);
        if (company == null) return false;
        _dbContext.Companies.Remove(company);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
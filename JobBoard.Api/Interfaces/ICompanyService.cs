using JobBoard.Api.DTOs;
using JobBoard.Api.Models;

namespace JobBoard.Api.Interfaces;

public interface ICompanyService
{
    Task<IEnumerable<CompanyResponse>> GetAllCompaniesAsync();
    Task<CompanyResponse?> GetCompanyByIdAsync(Guid id);
    Task<CompanyResponse> CreateCompanyAsync(CreateCompanyRequest request);
    Task<bool> UpdateCompanyAsync(Guid id, CreateCompanyRequest request);
    Task<bool> DeleteCompanyAsync(Guid id);
}
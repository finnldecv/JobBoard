using JobBoard.Api.DTOs;

namespace JobBoard.Api.Interfaces;

public interface IJobPostingService
{
    Task<IEnumerable<JobPostingResponse>> GetAllActiveJobsAsync();
    Task<JobPostingResponse?> GetJobByIdAsync(Guid id);
    Task<JobPostingResponse> CreateJobAsync(CreateJobPostingRequest requestDto);
    Task<bool> UpdateJobAsync(Guid id, CreateJobPostingRequest requestDto);
    Task<bool> DeleteJobAsync(Guid id);
}
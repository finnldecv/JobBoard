using JobBoard.Api.Interfaces;
using JobBoard.Api.Models;
using JobBoard.Api.DTOs;
using JobBoard.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace JobBoard.Api.Services;

public class JobPostingService : IJobPostingService
{
    private readonly JobBoardDbContext _dbContext;
    public JobPostingService(JobBoardDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<JobPostingResponse>> GetAllActiveJobsAsync(JobQueryParameters queryParameters)
    {
        var query = _dbContext.JobPostings
            .Include(j => j.Company)
            .Where(j => j.IsActive)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(queryParameters.SearchTerm))
        {
            query = query.Where(j => j.Title.Contains(queryParameters.SearchTerm) ||
                                     j.Description.Contains(queryParameters.SearchTerm));
        }

        var skipAmount = (queryParameters.Page - 1) * queryParameters.PageSize;

        return await query
            .Distinct()
            .OrderBy(j => j.Title)
            .Skip(skipAmount)
            .Take(queryParameters.PageSize)
            .Select(job => new JobPostingResponse
            {
                Id = job.Id,
                Title = job.Title,
                Description = job.Description,
                Location = job.Location,
                CreatedAt = job.CreatedAt,
            })
            .ToListAsync();
    }
    public async Task<JobPostingResponse?> GetJobByIdAsync(Guid id)
    {
        var job = await _dbContext.JobPostings.FindAsync(id);
        if (job == null || !job.IsActive)
        {
            return null;
        }
        return new JobPostingResponse
        {
            Id = job.Id,
            Title = job.Title,
            Description = job.Description,
            Location = job.Location,
            CreatedAt = job.CreatedAt
        };
    }
    public async Task<JobPostingResponse> CreateJobAsync(CreateJobPostingRequest requestDto)
    {
        var newJob = new JobPosting
        {
            Title = requestDto.Title,
            Description = requestDto.Description,
            Location = requestDto.Location,
            CompanyId = requestDto.CompanyId
        };
        _dbContext.JobPostings.Add(newJob);
        await _dbContext.SaveChangesAsync();
        return new JobPostingResponse
        {
            Id = newJob.Id,
            Title = newJob.Title,
            Description = newJob.Description,
            Location = newJob.Location,
            CreatedAt = newJob.CreatedAt
        };
    }
    public async Task<bool> UpdateJobAsync(Guid id, CreateJobPostingRequest requestDto)
    {
        var existingJob = await _dbContext.JobPostings.FindAsync(id);
        if (existingJob == null || !existingJob.IsActive)
        {
            return false;
        }
        existingJob.Title = requestDto.Title;
        existingJob.Description = requestDto.Description;
        existingJob.Location = requestDto.Location;
        await _dbContext.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteJobAsync(Guid id)
    {
        var job = await _dbContext.JobPostings.FindAsync(id);
        if (job == null || !job.IsActive)
        {
            return false;
        }
        job.IsActive = false;
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
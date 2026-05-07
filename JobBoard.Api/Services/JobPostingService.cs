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
    public async Task<IEnumerable<JobPostingResponse>> GetAllActiveJobsAsync()
    {
        var jobs = await _dbContext.JobPostings
            .Where(j => j.IsActive)
            .ToListAsync();
            
        return  jobs.Select(job => new JobPostingResponse
        {
            Id = job.Id,
            Title = job.Title,
            Description = job.Description,
            Location = job.Location,
            CreatedAt = job.CreatedAt
        });
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
            Location = requestDto.Location
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
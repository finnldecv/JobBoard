using JobBoard.Api.Models;
using JobBoard.Api.DTOs;
using JobBoard.Api.Data;
using JobBoard.Api.Services;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using JobBoard.Api.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace JobBoard.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobPostingController : ControllerBase
{
    private readonly IJobPostingService _jobPostingService;

    public JobPostingController(IJobPostingService jobPostingService)
    {
        _jobPostingService = jobPostingService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllActiveJobs()
    {
        var jobs = await _jobPostingService.GetAllActiveJobsAsync();
        return Ok(jobs);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetJobById(Guid id)
    {
        var job = await _jobPostingService.GetJobByIdAsync(id);
        return Ok(job);
    }
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateJob(CreateJobPostingRequest requestDto)
    {
        var responseDto = await _jobPostingService.CreateJobAsync(requestDto);
        return CreatedAtAction(nameof(GetJobById), new { Id = responseDto.Id }, responseDto);
    }
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateJob(Guid id, CreateJobPostingRequest requestDto)
    {
        var success = await _jobPostingService.UpdateJobAsync(id, requestDto);
        if (success)
        {
            return NoContent();
        }
        return NotFound();
    }
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteJob(Guid id)
    {
        var success = await _jobPostingService.DeleteJobAsync(id);
        if (success)
        {
            return NoContent();
        }
        return NotFound();
    }
}
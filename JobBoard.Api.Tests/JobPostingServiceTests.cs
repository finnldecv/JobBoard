using JobBoard.Api.Data;
using JobBoard.Api.DTOs;
using JobBoard.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace JobBoard.Api.Tests;

public class JobPostingServiceTests
{
    private JobBoardDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<JobBoardDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        return new JobBoardDbContext(options);
    }
    [Fact]
    public async Task CreateJobAsync()
    {
        // Arrange
        var dbContext = GetInMemoryDbContext();
        var service = new JobPostingService(dbContext);
        var requestDto = new CreateJobPostingRequest
        {
            Title = "Junior .NET Developer",
            Description = "Great entry level role",
            Location = "HCM City"
        };
        // Act
        var result = await service.CreateJobAsync(requestDto);
        // Assert
        Assert.NotNull(result);
        Assert.Equal("Junior .NET Developer", result.Title);
        Assert.NotEqual(Guid.Empty, result.Id);

        var jobInDb = await dbContext.JobPostings.FirstOrDefaultAsync();
        Assert.NotNull(jobInDb);
        Assert.Equal("HCM City", jobInDb.Location);
    }
}

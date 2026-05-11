using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using JobBoard.Api.Controllers;
using JobBoard.Api.Interfaces;
using JobBoard.Api.DTOs;

namespace JobBoard.Api.Tests;

public class JobPostingsControllerTests
{
    [Fact]
    public async Task GetAllActiveJobs_ReturnsOkResult_WithListOfJobs()
    {
        // --- 1. ARRANGE (Set up the fake environment) ---
        
        // Create the robot clone of your service
        var mockService = new Mock<IJobPostingService>();
        
        // Create some fake data we want the robot to hand back
        var fakeJobs = new List<JobPostingResponse> 
        { 
            new JobPostingResponse { Id = Guid.NewGuid(), Title = "Fake Software Engineer" } 
        };

        // Program the robot: "When the Waiter asks for jobs, hand them this fake list."
        mockService.Setup(s => s.GetAllActiveJobsAsync(It.IsAny<JobQueryParameters>()))
                   .ReturnsAsync(fakeJobs);

        // Give the robot clone to the Controller (The Waiter doesn't know it's a fake!)
        var controller = new JobPostingsController(mockService.Object);

        // --- 2. ACT (Press the button) ---
        
        var queryParams = new JobQueryParameters(); // Just an empty search
        var result = await controller.GetAllActiveJobs(queryParams);

        // --- 3. ASSERT (Did the Waiter do their job?) ---
        
        // Did we get a 200 OK HTTP response?
        var okResult = Assert.IsType<OkObjectResult>(result);
        
        // Is the data inside the response a List of JobPostings?
        var returnValue = Assert.IsType<List<JobPostingResponse>>(okResult.Value);
        
        // Did the Waiter hand us exactly 1 job (our fake job)?
        Assert.Single(returnValue); 
        Assert.Equal("Fake Software Engineer", returnValue[0].Title);
    }
}
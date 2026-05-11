using Microsoft.EntityFrameworkCore;
using JobBoard.Api.Models;

namespace JobBoard.Api.Data;

public class JobBoardDbContext : DbContext
{
    public JobBoardDbContext(DbContextOptions<JobBoardDbContext> options) : base(options)
    {
    }
    public DbSet<JobPosting> JobPostings { get; set; }
    public DbSet<Company> Companies { get; set; }
}
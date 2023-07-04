using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WeatherForeCastAPI.Data;

namespace WeatherForeCast.Test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Assert.True(1 == 1);
    }

    [Fact]
    public async Task CustomerIntegrationTest()
    {
        //> Create Db Context:

        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        var connectionString = config.GetSection("ConnectionString").Value;

        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer(connectionString);

        var context = new AppDbContext(optionsBuilder.Options);

        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();


        //> Check Endpoints (Simulations):
        Assert.True(1 == 1);

             
    }
}
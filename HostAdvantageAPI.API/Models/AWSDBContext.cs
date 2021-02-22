using Amazon;
using Amazon.DynamoDBv2;
using Microsoft.EntityFrameworkCore;


namespace HostAdvantageAPI.API.Models
{
    public class AWSDBContext : DbContext
    {
        public AWSDBContext(DbContextOptions<AWSDBContext> options)
            : base(options)
        {
            var clientConfig = new AmazonDynamoDBConfig();
            clientConfig.RegionEndpoint = RegionEndpoint.EUWest2;
            var client = new AmazonDynamoDBClient(clientConfig);
        }

        public DbSet<User> User { get; set; }
    }
}

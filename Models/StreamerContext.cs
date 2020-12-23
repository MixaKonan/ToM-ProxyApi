using Microsoft.EntityFrameworkCore;

namespace TomProxyApi.Models
{
    public class StreamerContext : DbContext
    {
        public StreamerContext(DbContextOptions<StreamerContext> options)
            : base(options)
        {
        }

        public DbSet<Streamer> Streamers { get; set; }
    }
}
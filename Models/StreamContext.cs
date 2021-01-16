using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace TomProxyApi.Models
{
    public class StreamContext : DbContext
    {
        public StreamContext(DbContextOptions<StreamContext> options)
            : base(options)
        {
            
        }

        public DbSet<Stream> Streams { get; set; }
        public DbSet<Streamer> Streamers { get; set; }
    }
}
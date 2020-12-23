using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TomProxyApi.Models;

namespace TomProxyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StreamersController : Controller
    {
        private readonly StreamerContext _db;

        public StreamersController(StreamerContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public IEnumerable<Streamer> Get()
        {
            return _db.Streamers.ToList();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TomProxyApi.Models;

namespace TomProxyApi.Controllers
{
    [ApiController]
    [Route("/streamers")]
    public class StreamersController : Controller
    {
        private readonly StreamContext _db;

        public StreamersController(StreamContext db)
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
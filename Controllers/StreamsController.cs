using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TomProxyApi.Models;

namespace TomProxyApi.Controllers
{
    [ApiController]
    [Route("/streams")]
    public class StreamsController : Controller
    {
        private readonly StreamContext _db;

        public StreamsController(StreamContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public List<Stream> Get(string streamerName)
        {
                var query =
                    from streamers in _db.Streamers
                    join streams in _db.Streams on streamers.id equals streams.streamer_id
                    where streamers.name == streamerName
                    select streams;

                return query.AsEnumerable().ToList();
        }
        
        [HttpGet]
        [Route("/streams/{uuid}")]
        public List<Stream> Get(Guid uuid)
        {
            return _db.Streams.Where(stream => stream.uuid == uuid).ToList();
        }
    }
}
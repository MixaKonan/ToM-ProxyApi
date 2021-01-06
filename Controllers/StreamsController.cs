using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TomProxyApi.Models;

namespace TomProxyApi.Controllers
{
    [ApiController]
    [Route("/streams")]
    public class StreamsController : Controller
    {
        private readonly StreamContext _db;

        private readonly List<string> _streamFields = new List<string>
        {
            "uuid",
            "date",
            "duration",
            "game",
            "title",
            "streamer_id"
        };

        public StreamsController(StreamContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public List<Stream> Get(string streamerName, string orderBy = "date", string sortBy = "desc")
        {
            var streamers = (from str in _db.Streamers select str.name).ToList();

            foreach (var dbStreamerName in streamers)
            {
                if (streamerName == dbStreamerName)
                {
                    foreach (var field in _streamFields)
                    {
                        if (orderBy == field)
                        {
                            if (sortBy == "desc" || sortBy == "asc")
                            {
                                return _db.Streams.FromSqlRaw(
                                        "SELECT * FROM streamers JOIN streams ON streamers.id = streams.streamer_id" +
                                        $" WHERE streamers.name = '{streamerName}' ORDER BY {orderBy} {sortBy}")
                                    .AsEnumerable()
                                    .ToList();
                            }
                            return new List<Stream> {new Stream {game = "WRONG QUERY"}};
                        }
                    }
                }
            }
            return new List<Stream> {new Stream {game = "WRONG QUERY"}};
        }
        
        [HttpGet]
        [Route("/streams/{uuid}")]
        public List<Stream> Get(Guid uuid)
        {
            return _db.Streams.Where(stream => stream.uuid == uuid).ToList();
        }
    }
}
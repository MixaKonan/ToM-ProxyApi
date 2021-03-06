﻿using System;
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

        private readonly string[] _streamFields =
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
            if (_db.Streamers.Any(str => str.name == streamerName))
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
                    }
                }
                return new List<Stream> {new Stream {game = "WRONG QUERY"}};
            }
            return new List<Stream> {new Stream {game = "WRONG QUERY"}};
        }
        
        [HttpGet]
        [Route("/streams/{uuid}")]
        public List<Stream> Get(Guid uuid)
        {
            return _db.Streams.Where(stream => stream.uuid == uuid).ToList();
        }
        
        [HttpGet]
        [Route("/streams/search")]
        public List<Stream> Get(string streamerName, string query)
        {
            var upperQuery = query.ToUpper();
            
            return _db.Streamers.Any(str => str.name == streamerName) ?
                _db.Streams.Where(str => str.title.ToUpper().Contains(upperQuery) || str.game.ToUpper().Contains(upperQuery)).ToList() :
                new List<Stream> {new Stream {game = "WRONG QUERY"}};
        }
    }
}
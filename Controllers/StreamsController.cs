using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TomProxyApi.Models;

namespace TomProxyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StreamsController : Controller
    {
        private readonly StreamContext _db;

        public StreamsController(StreamContext db)
        {
            _db = db;
        }

        [HttpGet]
        public List<Stream> Get()
        {
            return _db.Streams.ToList();
        }
    }
}
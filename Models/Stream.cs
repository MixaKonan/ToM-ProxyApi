using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TomProxyApi.Models
{
    [Table("streams")]
    public class Stream
    {
        [Key]
        public Guid uuid { get; set; }
        public DateTime date { get; set; }
        public long duration { get; set; }
        public string game { get; set; }
        public string title { get; set; }
        public int streamer_id { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TomProxyApi.Models
{
    [Table("streamers")]
    public class Streamer 
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string storage_endpoint { get; set; }
        public string user_id { get; set; }
        public bool is_hosted{ get; set; }
    }
}
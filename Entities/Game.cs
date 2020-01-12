using System;

namespace WebApi.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Platform { get; set; }
        public string Production { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}

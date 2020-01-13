using System;
using WebApi.Models.Games;

namespace WebApi.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public GameType Type { get; set; }
        public GamePlatform Platform { get; set; }
        public string Production { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}

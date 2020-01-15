using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Games
{
    public class GameModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        //public GameType Type { get; set; }
        //public GamePlatform Platform { get; set; }
        public string Production { get; set; }
        public DateTime CreatedTime { get; set; }
    }

    public enum GameType
    {
        Action,
        RPG,
        Survival,
        cRPG,
        CardGame
    }

    public enum GamePlatform
    {
        PC,
        XBOX,
        PLAYSTATION,
        NINTENDO
    }
}

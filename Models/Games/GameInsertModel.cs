using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Games
{
    public class GameInsertModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public GameType Type { get; set; }

        [Required]
        public GamePlatform Platform { get; set; }

        public string Production { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Games
{
    public class GameInsertModel
    {
        [Required(ErrorMessage ="Title is required!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Type is also required!!")]
        public GameType Type { get; set; }

        [Required(ErrorMessage = "Platform is required a little hehe!")]
        public GamePlatform Platform { get; set; }

        public string Production { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}

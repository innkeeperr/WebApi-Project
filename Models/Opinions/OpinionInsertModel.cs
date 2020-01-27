using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Opinions
{
    public class OpinionInsertModel
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public string Text { get; set; }
        public int Rate { get; set; }

        [Required]
        public int GameId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}

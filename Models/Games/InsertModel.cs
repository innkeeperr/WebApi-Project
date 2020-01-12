using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Games
{
    public class InsertModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Platform { get; set; }

        public string Production { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}

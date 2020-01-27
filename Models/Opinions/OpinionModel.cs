using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Opinions
{
    public class OpinionModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Rate { get; set; }
        public int GameId { get; set; }
        public int UserId { get; set; }
    }
}

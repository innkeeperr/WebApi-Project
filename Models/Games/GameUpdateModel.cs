using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Games
{
    public class GameUpdateModel
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string Platform { get; set; }
        public string Production { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}

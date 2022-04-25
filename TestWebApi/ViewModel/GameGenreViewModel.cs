using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class GameGenreViewModel
    {
        public long GenreId { get; set; }
        public GenreViewModel Genre { get; set; }
        public long GameId { get; set; }
        public GameViewModel Game { get; set; }
    }
}

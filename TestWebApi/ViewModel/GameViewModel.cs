using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class GameViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long StudioId { get; set; }
        public StudioViewModel Studio { get; set; }
        public List<GameGenreViewModel> GameGenreList { get; set; }
        public List<GenreViewModel> GenreList { get; set; }
    }
}

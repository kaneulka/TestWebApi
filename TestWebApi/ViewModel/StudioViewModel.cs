using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class StudioViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<GameViewModel> Games { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Repository.GameRepository
{
    public interface IGameRepository
    {
        GameViewModel Get(long id);
        List<GameViewModel> GetAll();
        void Insert(GameViewModel model);
        void Update(GameViewModel model);  
        void Delete(long id);
        void SaveChanges();
    }
}

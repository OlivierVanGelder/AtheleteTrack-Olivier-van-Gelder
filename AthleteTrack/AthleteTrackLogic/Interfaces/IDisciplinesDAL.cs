using AthleteTrackLogic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthleteTrackLogic.Interfaces
{
    public interface IDisciplinesDAL
    {
        public List<Discipline> GetDisciplines(int ID);

        public List<Discipline> GetAllDisciplines();
    }
}

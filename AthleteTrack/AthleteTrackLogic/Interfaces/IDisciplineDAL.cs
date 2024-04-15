using AthleteTrackLogic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthleteTrackLogic.Interfaces
{
    public interface IDisciplineDAL
    {
        public List<Discipline> GetDisciplines();

        public List<Discipline> GetDiscipline(int ID);
    }
}
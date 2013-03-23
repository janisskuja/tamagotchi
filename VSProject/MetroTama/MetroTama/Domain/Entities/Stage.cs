using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTama.Domain
{
    public class Stage
    {
        public int StageId;
        public string Name;
        public TimeSpan PoopTime;
        public TimeSpan EatTime;
        public TimeSpan EnergyTime;
        public TimeSpan StudyTime;
        public TimeSpan DirtyTime;
        public TimeSpan FunTime;
        public TimeSpan HealtTime;
        public int AgeFrom;
        public int AgeTo;
    }
}

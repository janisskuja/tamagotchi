using MetroTama.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTama.Domain.Repository
{
    class SayTextRepository
    {
        public List<SayText> GetSayText(int t_Parametter, int t_From, int t_To)
        {
            using (var db = new SQLite.SQLiteConnection(App.DBPath))
            {
                List<SayText> retList = new List<SayText>();
                try
                {
                    retList = (db.Table<SayText>().Where(
                    s => s.Parametter == t_Parametter &&  s.From == t_From && s.To == t_To)).ToList<SayText>();
                }
                catch
                {
                    retList = null;
                }
                return retList;
            }
        }
    }
}

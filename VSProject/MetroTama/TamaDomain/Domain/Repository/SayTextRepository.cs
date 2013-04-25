using System.Collections.Generic;
using System.Linq;
using TamaDomain.Domain.Entities;
using TamaDomain.Domain.Enumerator;

namespace TamaDomain.Domain.Repository
{
    public class SayTextRepository
    {
        public SayText GetSayText(int t_Parametter, int value)
        {
            using (var db = new SQLite.SQLiteConnection(Constants.DbPath))
            {
                SayText retList;
                try
                {
                    retList = (db.Table<SayText>().Where(
                    s => s.Parametter == t_Parametter && s.From <= value && s.To >= value)).SingleOrDefault();
                }
                catch
                {
                    retList = null;
                }
                return retList;
            }
        }

        public string getText(Pet pet, int parameter)
        {
            int value = 0;
            switch (parameter)
            {
                case (int)ParameterEnum.Health:
                    value = pet.Health;
                    break;
                case (int)ParameterEnum.Hunger:
                    value = pet.Hunger;
                    break;
                case (int)ParameterEnum.Discipline:
                    value = pet.Discipline;
                    break;
                case (int)ParameterEnum.Energy:
                    value = pet.Energy;
                    break;
                case (int)ParameterEnum.Hygene:
                    value = pet.Hygene;
                    break;
                case (int)ParameterEnum.Mood:
                    value = pet.Mood;
                    break;
            }
            SayText sayTexts = GetSayText(parameter, value);
            return sayTexts != null ? sayTexts.Text : "...";
        }
    }
}

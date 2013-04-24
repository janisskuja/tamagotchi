using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamaDomain.Domain.Entities;

namespace TamaDomain.Domain.Repository
{
   public class StageRepository
    {
     public Stage GetPetStage(int stageId)
       {
           using (var db = new SQLite.SQLiteConnection(Constants.DbPath))
           {
               Stage stage = new Stage();
               try
               {
                   stage = (db.Table<Stage>().Where(
                               s => s.StageId == stageId)).SingleOrDefault();
               }
               catch
               {
                   stage = null;
               }
               return stage;
           }
       }

     internal Stage GetPetNewStage(int age)
     {
         using (var db = new SQLite.SQLiteConnection(Constants.DbPath))
         {
             Stage stage = new Stage();
             try
             {
                 stage = (db.Table<Stage>().Where(
                             s => s.AgeFrom >= age && s.AgeTo <= age)).SingleOrDefault();
             }
             catch
             {
                 stage = null;
             }
             return stage;
         }
     }
    }
}

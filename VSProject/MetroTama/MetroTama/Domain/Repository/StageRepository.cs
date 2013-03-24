using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTama.Domain.Repository
{
    class StageRepository
    {
        public Stage GetStage() {
            Stage stage = new Stage();
            stage.StageId = 1;
            stage.Name = "Egg";
            //stage.DirtyTime = new TimeSpan(0, 0, 1, 0, 0);
            //stage.EnergyTime = new TimeSpan(0, 0, 0, 45, 0);
            //stage.FunTime = new TimeSpan(0, 0, 2, 00, 0);
            //stage.HealtTime = new TimeSpan(0, 0, 2, 00, 0);
            //stage.PoopTime = new TimeSpan(0, 0, 5, 00, 0);
            //stage.StudyTime = new TimeSpan(0, 0, 4, 00, 0);
            //stage.EatTime = new TimeSpan(0, 0, 0, 30, 0);

            stage.DirtyTime = new TimeSpan(0, 0, 0, 3, 0);
            stage.EnergyTime = new TimeSpan(0, 0, 0, 2, 0);
            stage.FunTime = new TimeSpan(0, 0, 0, 10, 0);
            stage.HealtTime = new TimeSpan(0, 0, 0, 3, 0);
            stage.PoopTime = new TimeSpan(0, 0, 0, 3, 0);
            stage.StudyTime = new TimeSpan(0, 0, 0, 10, 0);
            stage.EatTime = new TimeSpan(0, 0, 0, 2, 0);

            return stage;
        }
    }
}

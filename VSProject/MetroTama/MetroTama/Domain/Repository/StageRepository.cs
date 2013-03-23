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
            stage.DirtyTime = new TimeSpan(0, 0, 1, 00, 0); // 1 minute
            stage.EnergyTime = new TimeSpan(0, 0, 1, 00, 0); // 1 minute
            stage.FunTime = new TimeSpan(0, 0, 1, 00, 0); // 1 minute
            stage.HealtTime = new TimeSpan(0, 0, 1, 00, 0); // 1 minute
            stage.PoopTime = new TimeSpan(0, 0, 1, 00, 0); // 1 minute
            stage.StudyTime = new TimeSpan(0, 0, 1, 00, 0); // 1 minute
            stage.EatTime = new TimeSpan(0, 0, 1, 00, 0); // 1 minute
            return stage;
        }
    }
}

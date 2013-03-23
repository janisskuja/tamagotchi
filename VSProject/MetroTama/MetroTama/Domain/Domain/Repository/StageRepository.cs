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
            return stage;
        }
    }
}

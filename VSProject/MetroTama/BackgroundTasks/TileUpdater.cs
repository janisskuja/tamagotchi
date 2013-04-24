using System;
using TamaDomain.Domain.Entities;
using TamaDomain.Domain.Repository;
using Windows.ApplicationModel.Background;
using Windows.UI.Notifications;

namespace BackgroundTasks
{
    public sealed class TileUpdater : IBackgroundTask
    {
        private PetRepository _petRepo = new PetRepository();
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            Pet pet = _petRepo.GetPet();
            string tileText = _petRepo.UpdatePetFromBackground();
            var defferal = taskInstance.GetDeferral();

            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            updater.EnableNotificationQueue(true);

            updater.Clear();

            var tile = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquareText02);
            tile.GetElementsByTagName("text")[0].InnerText = pet  != null ? pet.Name + " :" : "Your pet ran away :(";
            tile.GetElementsByTagName("text")[1].InnerText = tileText;

            updater.Update(new TileNotification(tile));

            defferal.Complete();
        }
    }
}

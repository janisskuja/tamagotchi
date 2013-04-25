using System;
using System.Collections.Generic;
using MetroTama.Common;
using MetroTama.Services;
using TamaDomain.Domain.Entities;
using TamaDomain.Domain.Repository;
using Windows.ApplicationModel.Background;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace MetroTama
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class NewPetPage : MetroTama.Common.LayoutAwarePage
    {
        readonly PetService _petService = new PetService();
        readonly PetRepository _petRepository = new PetRepository();
        private Pet newPet;
        private GamePage _gamePage;
        private const string TASK_NAME = "TileUpdater";
        private const string TASK_ENTRY = "BackgroundTasks.TileUpdater";

        public NewPetPage(GamePage gamePage)
        {
            this.InitializeComponent();
            newPet = _petService.GeneratePet();
            _gamePage = gamePage;
            Window.Current.Activated += Current_Activated;
            
        }

        private void Current_Activated(object sender, WindowActivatedEventArgs e)
        {
            // Initialize the database if necessary
            DbInitRepository.InitData();
        }


        private async void RegisterBacgroundTask()
        {
            var result = await BackgroundExecutionManager.RequestAccessAsync();
            if (result == BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity ||
                result == BackgroundAccessStatus.AllowedWithAlwaysOnRealTimeConnectivity)
            {
                foreach (var task in BackgroundTaskRegistration.AllTasks)
                {
                    if (task.Value.Name == TASK_NAME)
                        task.Value.Unregister(true);
                }

                BackgroundTaskBuilder builder = new BackgroundTaskBuilder();
                builder.Name = TASK_NAME;
                builder.TaskEntryPoint = TASK_ENTRY;
                builder.SetTrigger(new TimeTrigger(15, false));
                var registration = builder.Register();
            }
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        private void Star_Click(object sender, RoutedEventArgs e)
        {
            newPet.Name = TbPetName.Text;
            _petRepository.AddPet(newPet);
            _gamePage._game.IsGameStarted = true;
            RegisterBacgroundTask();
            Window.Current.Content = _gamePage;
            Window.Current.Activate();
        }
    }
}

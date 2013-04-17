using System;
using MetroTama.Domain.Entities;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MonoGame.Framework;
using MetroTama.Domain;
using MetroTama.Domain.Repository;
using Windows.ApplicationModel.Background;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI;
using Windows.UI.Xaml.Media;
using MetroTama.Services;

namespace MetroTama
{
    /// <summary>
    /// The root page used to display the game.
    /// </summary>
    public sealed partial class GamePage : SwapChainBackgroundPanel
    {
        readonly Game1 _game;

        private static string FOOD = "food";
        private static string ACTIVITY = "activity";
        private static int FOOD_APPLE = 1;
        private static int FOOD_BURGER = 2;
        private static int FOOD_DRINK = 3;
        private static int ACTIVITY_BALL = 4;
        private static int ACTIVITY_READ = 5;
        private static int CLEAN_OBJECT = 6;
        private static int MEDIC_OBJECT = 7;

        public static string TimeTriggeredTaskProgress = "";

        private SayTextService sayTextService = new SayTextService();

        public GamePage(string launchArguments)
        {
            this.InitializeComponent();

            // Create the game.
            _game = XamlGame<Game1>.Create(launchArguments, Window.Current.CoreWindow, this);

            _game.SetXamlPage(this);

            ProgressHP.Maximum = 100;
            ProgressEN.Maximum = 100;
            ProgressHYG.Maximum = 100;
            ProgressHUN.Maximum = 100;
            ProgressMD.Maximum = 100;
            ProgressSM.Maximum = 100;
            // TODO: fix this method

           // RegisterBackgroundTask();
        }

        private void Button_Feed_Click(object sender, RoutedEventArgs e)
        {
            ActivateSubcategory(FOOD);
        }

        private void Button_Play_Click(object sender, RoutedEventArgs e)
        {
            ActivateSubcategory(ACTIVITY);
        }

        private void Button_Clean_Click(object sender, RoutedEventArgs e)
        {
            HideAllSubcategories();
            _game.Clean(CLEAN_OBJECT);
        }

        private void Button_First_Aid_Click(object sender, RoutedEventArgs e)
        {
            HideAllSubcategories();
            _game.FirstAid(MEDIC_OBJECT);
        }

        private void Button_Light_Click(object sender, RoutedEventArgs e)
        {
            HideAllSubcategories();
            _game.Light();
        }

        private void ActivateSubcategory(string name)
        {
            HideAllSubcategories();
            switch (name)
            {
                case "food":
                    GridFood.Visibility = Visibility.Visible;
                    break;
                case "activity":
                    GridActivity.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void HideAllSubcategories()
        {
            GridFood.Visibility = Visibility.Collapsed;
            GridActivity.Visibility = Visibility.Collapsed;
        }

        private void BtnApple_Click(object sender, RoutedEventArgs e)
        {
            _game.Feed(FOOD_APPLE);
        }

        private void BtnBurger_Click(object sender, RoutedEventArgs e)
        {
            _game.Feed(FOOD_BURGER);
        }

        private void BtnDrink_Click(object sender, RoutedEventArgs e)
        {
            _game.Feed(FOOD_DRINK);
        }

        private void BtnBaseball_Click(object sender, RoutedEventArgs e)
        {
            _game.Play(ACTIVITY_BALL);
        }

        private void BtnBook_Click(object sender, RoutedEventArgs e)
        {
            _game.Read(ACTIVITY_READ);
        }

        public void UpdateText(Pet pet)
        {

            ProgressHP.Value = pet.Healt;
            CheckProgressHp();
            ProgressEN.Value = pet.Energy;
            ProgressHYG.Value = pet.Hygene;
            ProgressMD.Value = pet.Fun;
            ProgressSM.Value = pet.Study;
            ProgressHUN.Value = pet.Hungry;
            TextHP.Text = pet.Healt.ToString();
            TextEN.Text = pet.Energy.ToString();
            TextHYG.Text = pet.Hygene.ToString();
            TextMD.Text = pet.Fun.ToString();
            TextSM.Text = pet.Study.ToString();
            TextHUN.Text = pet.Hungry.ToString();

        }

        private void CheckProgressHp()
        {
            // TODO: fix progress bars
            //SolidColorBrush colorBrush = new SolidColorBrush(Color.FromArgb(0, 242, 34, 12));

            //if (ProgressHP.Value > 25)
            //{
            //    ProgressHP.Foreground = colorBrush;
            //}
        }

        /// <summary>
        /// Register a TimeTriggeredTask.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void RegisterBackgroundTask()
        {
            //
            // Time triggered tasks can only run when the application is on the lock screen.
            // Time triggered tasks can be registered even if the application is not on the lockscreen.
            // 
            await BackgroundExecutionManager.RequestAccessAsync();

            var task = BackgroundTask.RegisterBackgroundTask(BackgroundTask.BackgroundTaskEntryPoint,
                                                                   BackgroundTask.TimeTriggeredTaskName,
                                                                   new TimeTrigger(15, false),
                                                                   null);
            AttachProgressAndCompletedHandlers(task);
            UpdateUI();
        }

        /// <summary>
        /// Attach progress and completed handers to a background task.
        /// </summary>
        /// <param name="task">The task to attach progress and completed handlers to.</param>
        private void AttachProgressAndCompletedHandlers(IBackgroundTaskRegistration task)
        {
            task.Progress += new BackgroundTaskProgressEventHandler(OnProgress);
            task.Completed += new BackgroundTaskCompletedEventHandler(OnCompleted);
        }
        /// <summary>
        /// Handle background task progress.
        /// </summary>
        /// <param name="task">The task that is reporting progress.</param>
        /// <param name="e">Arguments of the progress report.</param>
        private void OnProgress(IBackgroundTaskRegistration task, BackgroundTaskProgressEventArgs args)
        {
            var progress = "Progress: " + args.Progress + "%";
            TimeTriggeredTaskProgress = progress;
            UpdateUI();
        }
        /// <summary>
        /// Handle background task completion.
        /// </summary>
        /// <param name="task">The task that is reporting completion.</param>
        /// <param name="e">Arguments of the completion report.</param>
        private void OnCompleted(IBackgroundTaskRegistration task, BackgroundTaskCompletedEventArgs args)
        {
            UpdateUI();
        }

        /// <summary>
        /// Update the scenario UI.
        /// </summary>
        private async void UpdateUI()
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            {
                //RegisterButton.IsEnabled = !BackgroundTaskSample.TimeTriggeredTaskRegistered;
                //UnregisterButton.IsEnabled = BackgroundTaskSample.TimeTriggeredTaskRegistered;
                //Progress.Text = BackgroundTaskSample.TimeTriggeredTaskProgress;
                //Status.Text = BackgroundTaskSample.GetBackgroundTaskStatus(BackgroundTaskSample.TimeTriggeredTaskName);

                //TODO: update pet in background
                _game.Pet.UpdateFromBackgroud();
                //TODO: output text on live tile
                TriggerTest.Text = sayTextService.GetText(_game.Pet);
            });


        }
    }
}

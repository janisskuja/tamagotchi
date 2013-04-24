using MetroTama.Common;
using MetroTama.Domain.Entities;
using MetroTama.Domain.Enumerator;
using MetroTama.Domain.Repository;
using MetroTama.Services;
using TamaDomain.Domain.Entities;
using TamaDomain.Domain.Enumerator;
using TamaDomain.Domain.Repository;
using Windows.UI.Xaml;
using MonoGame.Framework;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;


namespace MetroTama
{
    /// <summary>
    /// The root page used to display the game.
    /// </summary>
    public sealed partial class GamePage : LayoutAwarePage
    {
        public Game1 _game;
        public Pet _pet;
        private GameObjectService _gameObjectService = new GameObjectService();
        readonly PetRepository _petRepository = new PetRepository();


        public GamePage(string launchArguments)
        {
            InitializeComponent();
            InitializeGame(launchArguments);
            Window.Current.SizeChanged += Current_SizeChanged;
            Window.Current.Activated += Current_Activated;
        }

        private void Current_Activated(object sender, Windows.UI.Core.WindowActivatedEventArgs e)
        {
            //using (var db = new SQLite.SQLiteConnection(App.DBPath))
            //{
            //    db.DeleteAll<Pet>();
            //}
            
            // See if pet exists, if not create one
            if (_petRepository.GetPet() == null)
            {
                Window.Current.Content = new NewPetPage(this);
                Window.Current.Activate();
            }
            else
            {
                _game.IsGameStarted = true;
            }
        }

        private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            if (BottomAppBar != null && BottomAppBar.IsOpen && TopAppBar != null && TopAppBar.IsOpen)
            {
                UpdateAppBarViewState();
            }
        }

        private void UpdateAppBarViewState()
        {
            string viewState = Windows.UI.ViewManagement.ApplicationView.Value.ToString();
            // Get the app bar's root Panel.
            Panel root = BtmAppBar.Content as Panel;
            if (root != null)
            {
                // Get the Panels that hold the controls.
                foreach (Panel panel in root.Children)
                {
                    // Get each control and update its state if 
                    // it's a Button or ToggleButton.
                    foreach (UIElement child in panel.Children)
                    {
                        if (child.GetType() == typeof(Button) ||
                            child.GetType() == typeof(ToggleButton))
                        {
                            VisualStateManager.GoToState((ButtonBase)child, viewState, true);
                        }
                    }
                }
            }
            switch (viewState)
            {
                case "Snapped":
                    Grid.SetRow(BtmRightAppBarPanel, 1);
                    TopRightAppBarPanel.Visibility = Visibility.Collapsed;
                    TopLeftAppBarPanel.HorizontalAlignment = HorizontalAlignment.Center;
                    break;
                default:
                    Grid.SetRow(BtmRightAppBarPanel, 0);
                    TopRightAppBarPanel.Visibility = Visibility.Visible;
                    TopLeftAppBarPanel.HorizontalAlignment = HorizontalAlignment.Left;
                    break;
            }
        }

        private void ShowSubcategory(UiSubcategoryEnum subcategory)
        {
            switch (subcategory)
            {
                case UiSubcategoryEnum.Food:
                    BtmLeftActionSubPanel.Visibility = Visibility.Collapsed;
                    BtmLeftFoodSubPanel.Visibility = (BtmLeftFoodSubPanel.Visibility == Visibility.Collapsed)
                                                         ? Visibility.Visible
                                                         : Visibility.Collapsed;
                    break;
                case UiSubcategoryEnum.Action:
                    BtmLeftFoodSubPanel.Visibility = Visibility.Collapsed;
                    BtmLeftActionSubPanel.Visibility = (BtmLeftActionSubPanel.Visibility == Visibility.Collapsed)
                                                       ? Visibility.Visible
                                                       : Visibility.Collapsed;
                    break;
                default:
                    break;
            }
        }


        private void Btm_AppBar_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateAppBarViewState();
        }

        private void Btm_AppBar_Unloaded(object sender, RoutedEventArgs e)
        {
            //  throw new System.NotImplementedException();
        }

        private void Top_AppBar_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateAppBarViewState();
        }

        private void Top_AppBar_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void Food_Click(object sender, RoutedEventArgs e)
        {
            ShowSubcategory(UiSubcategoryEnum.Food);
        }
        private void Action_Click(object sender, RoutedEventArgs e)
        {
            ShowSubcategory(UiSubcategoryEnum.Action);
        }

        private void Clean_Click(object sender, RoutedEventArgs e)
        {
            _gameObjectService.UseObject(_game, GameObjectEnum.Soap);
            // Kaut kas jādomā ar mazgāšanos
        }

        private void Heal_Click(object sender, RoutedEventArgs e)
        {
            _gameObjectService.UseObject(_game, GameObjectEnum.Medkit);

        }

        private void Light_Click(object sender, RoutedEventArgs e)
        {
            //Sleeping mode
        }

        private void Apple_Click(object sender, RoutedEventArgs e)
        {
            _gameObjectService.UseObject(_game, GameObjectEnum.Apple);
        }

        private void Burger_Click(object sender, RoutedEventArgs e)
        {
            _gameObjectService.UseObject(_game, GameObjectEnum.Burger);
        }

        private void Watter_Click(object sender, RoutedEventArgs e)
        {
            _gameObjectService.UseObject(_game, GameObjectEnum.Watter);
        }

        private void Ball_Click(object sender, RoutedEventArgs e)
        {
            _gameObjectService.UseObject(_game, GameObjectEnum.Ball);
        }

        private void Read_Click(object sender, RoutedEventArgs e)
        {
            _gameObjectService.UseObject(_game, GameObjectEnum.Book);
        }

        internal void InitializeGame(string launchArguments)
        {
            _game = XamlGame<Game1>.Create(launchArguments, Window.Current.CoreWindow, DxSwapChainPanel);
            _game.SetXamlPage(this);
        }

        public void UpdateStatusUI()
        {
            _pet = _petRepository.GetPet();
            if (_pet != null)
            {
                HealthProgressBar.Value = _pet.Health;
                EnergyProgressBar.Value = _pet.Energy;
                HungerProgressBar.Value = _pet.Hunger;
                MoodProgressBar.Value = _pet.Hunger;
                HygeneProgressBar.Value = _pet.Hygene;
                DisciplineProgressBar.Value = _pet.Discipline;
                PetName.Text = _pet.Name;
                if (_pet.Gender == (int)GenderEnum.Female)
                {
                    MalePath.Visibility = Visibility.Collapsed;
                    FemalePath.Visibility = Visibility.Visible;
                }
                else
                {
                    MalePath.Visibility = Visibility.Visible;
                    FemalePath.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}

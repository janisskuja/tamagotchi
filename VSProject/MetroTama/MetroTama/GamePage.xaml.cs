using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MonoGame.Framework;
using MetroTama.Domain;
using MetroTama.Domain.Repository;

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

        public GamePage(string launchArguments)
        {
            this.InitializeComponent();

            // Create the game.
            _game = XamlGame<Game1>.Create(launchArguments, Window.Current.CoreWindow, this);

            _game.SetXAMLPage(this);
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
            _game.Clean();
        }

        private void Button_First_Aid_Click(object sender, RoutedEventArgs e)
        {
            _game.FirstAid();
        }

        private void Button_Light_Click(object sender, RoutedEventArgs e)
        {
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
            TextHP.Text = pet.Healt.ToString();
            TextEN.Text = pet.Energy.ToString();
            TextHYG.Text = pet.Hygene.ToString();
            TextMD.Text = pet.Fun.ToString();
            TextSM.Text = pet.Study.ToString();
        }
    }
}

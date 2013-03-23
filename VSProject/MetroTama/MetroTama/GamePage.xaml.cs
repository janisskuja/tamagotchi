using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MonoGame.Framework;


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

        public GamePage(string launchArguments)
        {
            this.InitializeComponent();

            // Create the game.
            _game = XamlGame<Game1>.Create(launchArguments, Window.Current.CoreWindow, this);
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
            Game1.Clean();
        }

        private void Button_First_Aid_Click(object sender, RoutedEventArgs e)
        {
            Game1.FirstAid();
        }

        private void Button_Light_Click(object sender, RoutedEventArgs e)
        {
            Game1.Light();
        }

        private void Button_Read_Click(object sender, RoutedEventArgs e)
        {
            Game1.Read();
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

        }

        private void BtnBurger_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDrink_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnBaseball_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnBook_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

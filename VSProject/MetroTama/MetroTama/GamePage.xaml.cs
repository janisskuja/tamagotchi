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

        public GamePage(string launchArguments)
        {
            this.InitializeComponent();

            // Create the game.
            _game = XamlGame<Game1>.Create(launchArguments, Window.Current.CoreWindow, this);
        }

        private void Button_Feed_Click(object sender, RoutedEventArgs e)
        {
            //Game1.Feed();
        }

        private void Button_Play_Click(object sender, RoutedEventArgs e)
        {
            Game1.Play();
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
    }
}

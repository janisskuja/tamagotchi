using MetroTama.Domain.Enumerator;
using TCD.Controls;
using Windows.UI;
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
        readonly Game1 _game;

        public GamePage(string launchArguments)
        {
            InitializeComponent();
        

            // Create the game.
            _game = XamlGame<Game1>.Create(launchArguments, Window.Current.CoreWindow, DxSwapChainPanel);
            _game.SetXamlPage(this);

            Window.Current.SizeChanged += Current_SizeChanged;
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
                    Grid.SetRow(BtmRightAppBarPanel,1);
                    break;
                default:
                    Grid.SetRow(BtmRightAppBarPanel, 0);
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
           
        }

        private void Heal_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Light_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Apple_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Burger_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Watter_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Ball_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Read_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}

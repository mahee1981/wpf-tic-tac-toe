using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUITicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void GridBoxClick(object sender, RoutedEventArgs e)
        {
            var myButton = e.Source as ToggleButton;

            myButton.Content = TicTacToe.Game.ReadInput(myButton.Tag.ToString());

            myButton.IsEnabled = false;
            if (!TicTacToe.Game.IsActive)
            {
                MessageBox.Show(TicTacToe.Game.EndGame());
            }
        }
        private void ResetGameClick(object sender, RoutedEventArgs e)
        {
            foreach(ToggleButton gridSlot in GameGrid.Children)
            {
                gridSlot.IsEnabled = true;
                gridSlot.IsChecked = false;
                gridSlot.Content = "";
            }
            TicTacToe.Game.Reset();
        }

    }
}

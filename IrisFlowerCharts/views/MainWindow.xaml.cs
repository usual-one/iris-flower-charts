using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IrisFlowerCharts.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            MinimizeButton.MouseDown += (sender, e) =>
            {
                WindowState = WindowState.Minimized;
            };

            CloseButton.MouseDown += (sender, e) =>
            {
                Application.Current.Shutdown();
            };

            TopGrid.MouseDown += (sender, e) =>
            {
                if (e.ChangedButton == MouseButton.Left)
                    DragMove();
            };
        }
    }
}

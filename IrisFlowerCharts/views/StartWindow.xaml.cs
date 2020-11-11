using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IrisFlowerCharts.Views
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
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

            ControlGrid.MouseDown += (sender, e) =>
            {
                if (e.ChangedButton == MouseButton.Left)
                    DragMove();
            };
        }
    }
}

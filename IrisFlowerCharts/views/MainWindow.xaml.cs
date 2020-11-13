using System;
using System.Windows;
using System.Windows.Input;

namespace IrisFlowerCharts.Views
{
    /// <summary>Interaction logic for main window view.</summary>
    public partial class MainWindow : Window
    {

        /// <summary>Constructor.</summary>
        public MainWindow()
        {
            InitializeComponent();

            SepalWidthAxisY.LabelFormatter = label => Math.Round(label, 2).ToString();
            SepalLengthAxisY.LabelFormatter = label => Math.Round(label, 2).ToString();
            PetalWidthAxisY.LabelFormatter = label => Math.Round(label, 2).ToString();
            PetalLengthAxisY.LabelFormatter = label => Math.Round(label, 2).ToString();

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
